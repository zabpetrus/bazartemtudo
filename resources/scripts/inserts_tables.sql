USE [BazarDB];
GO


PRINT 'Fornecedores populados';


-- Inserção 1
INSERT INTO [dbo].[Transportadoras] ([NomeTransportadora],[CNPJ]  ,[TipoServico] ,[CustoFrete] ,[Data_Registro] ,[Data_Atualizacao])
     SELECT 'Transportadora A', '11.222.333/0001-01', 1, 50.00, GETDATE(), GETDATE() 
	 WHERE NOT EXISTS (SELECT 1 FROM [dbo].[Transportadoras] f WHERE f.CNPJ = '11.222.333/0001-01');

-- Inserção 2
INSERT INTO [dbo].[Transportadoras] ([NomeTransportadora],[CNPJ]  ,[TipoServico] ,[CustoFrete] ,[Data_Registro] ,[Data_Atualizacao])
     SELECT 'Transportadora B', '22.333.444/0001-02', 2, 75.00, GETDATE(), GETDATE()
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[Transportadoras] f WHERE f.CNPJ = '11.222.333/0001-01');

-- Inserção 3
INSERT INTO [dbo].[Transportadoras] ([NomeTransportadora],[CNPJ]  ,[TipoServico] ,[CustoFrete] ,[Data_Registro] ,[Data_Atualizacao])
   SELECT 'Transportadora C', '33.444.555/0001-03', 1, 60.00, GETDATE(), GETDATE()
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[Transportadoras] f WHERE f.CNPJ = '11.222.333/0001-01');

-- Inserção 4
INSERT INTO [dbo].[Transportadoras] ([NomeTransportadora],[CNPJ]  ,[TipoServico] ,[CustoFrete] ,[Data_Registro] ,[Data_Atualizacao])
SELECT 'Transportadora D', '44.555.666/0001-04', 3, 90.00, GETDATE(), GETDATE()
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[Transportadoras] f WHERE f.CNPJ = '11.222.333/0001-01');

-- Inserção 5
INSERT INTO [dbo].[Transportadoras] ([NomeTransportadora],[CNPJ]  ,[TipoServico] ,[CustoFrete] ,[Data_Registro] ,[Data_Atualizacao])
SELECT 'Transportadora E', '55.666.777/0001-05', 2, 80.00, GETDATE(), GETDATE()
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[Transportadoras] f WHERE f.CNPJ = '11.222.333/0001-01');





-- Inserindo atraves da carga

INSERT INTO [dbo].[Clientes]
(Nome, Email, CPF, Phone, Data_Registro, Data_Atualizacao)
SELECT DISTINCT 
Ca.buyer_name, Ca.buyer_email, Ca.cpf, Ca.buyer_phone_number, GETDATE(), GETDATE()
FROM Carga Ca
LEFT JOIN [Clientes] Cl ON Cl.CPF = Ca.cpf
WHERE Cl.CPF IS NULL;




INSERT INTO [dbo].[Produtos]
(product_name, SKU, UPC, Valor, Data_Registro, Data_Atualizacao)
SELECT DISTINCT Ca.product_name, ca.sku, ca.upc,ca.item_price,GETDATE(), GETDATE() FROM Carga Ca
LEFT JOIN Produtos ON Produtos.UPC = Ca.upc WHERE NOT EXISTS 
(SELECT 1 FROM Produtos WHERE Produtos.UPC = Ca.upc );

PRINT 'Produtos populados';



INSERT INTO Enderecos (
    order_id, 
    ship_address1, 
    ship_address2, 
    ship_address3, 
    ship_city, 
    ship_postal_code, 
    ship_country, 
    ship_state, 
    Data_Registro, 
    Data_Atualizacao
)
SELECT DISTINCT 
    ca.order_id, 
    ca.ship_address_1, 
    ca.ship_address_2, 
    ca.ship_address_3, 
    ca.ship_city, 
    ca.ship_postal_code, 
    ca.ship_country, 
    ca.ship_state, 
    GETDATE() AS Data_Registro,  -- Usando a função GETDATE() para inserir a data atual
    GETDATE() AS Data_Atualizacao -- Usando a função GETDATE() para inserir a data atual
FROM Carga ca
LEFT JOIN Enderecos e ON e.order_id = ca.order_id
WHERE NOT EXISTS (
    SELECT 1 
    FROM Enderecos 
    WHERE order_id = ca.order_id
);


INSERT INTO [dbo].[Pedidos]
    ([Order_id]
    ,[Purchase_Date]
    ,[Payments_Date]
    ,[Currency]
    ,[Ship_service_level]
    ,[Endereco_Id]
    ,[ClientesId]
    ,[Data_Registro]
    ,[Data_Atualizacao])

SELECT DISTINCT
    ca.order_id,
    ca.purchase_date,
    ca.payments_date,
    ca.currency,
    ca.ship_service_level,
    en.Id, -- Assumindo que Endereco_Id é a chave primária da tabela Enderecos
    cli.id,
    GETDATE() AS Data_Registro,
    GETDATE() AS Data_Atualizacao
FROM Carga ca
LEFT JOIN Clientes cli ON cli.CPF = ca.cpf
LEFT JOIN Pedidos pe ON pe.Order_id = ca.order_id
LEFT JOIN Enderecos en ON en.order_id = ca.order_id
WHERE NOT EXISTS (
    SELECT 1 FROM Pedidos WHERE Pedidos.Order_id = ca.order_id
);





INSERT INTO [dbo].[ItensPedidos]
           (
		    [PedidoId],
			[ProdutoId],
			[Order_Item_id]
           ,[Item_Price]
           ,[Quantity_Purchased]        
           ,[Data_Registro]
           ,[Data_Atualizacao]         
		   )
SELECT DISTINCT
    pe.Id AS Pedido_ID,
    pr.Id AS Produto_ID,
    ca.order_item_id,
    ca.item_price,
    ca.quantity_purchased,
    GETDATE() AS DataCriacao,
    GETDATE() AS DataAtualizacao
FROM Pedidos pe
LEFT JOIN Carga ca ON ca.order_id = pe.Order_id
LEFT JOIN Produtos pr ON ca.upc = pr.upc AND ca.sku = pr.sku
WHERE NOT EXISTS (
    SELECT 1 
    FROM ItensPedidos d
    WHERE d.PedidoId = pe.Id 
    AND d.ProdutoId = pr.Id
    AND d.order_item_id = ca.order_item_id
);
	







INSERT INTO [dbo].[Estoque]
    ([Produtos_ID], [Quantidade], [Estoque_Minimo], [Data_Registro], [Data_Atualizacao])
SELECT 
    oi.ProdutoId, 
    0 AS qte,
    SUM(oi.Quantity_Purchased) AS minimal_qte,
    GETDATE() AS Data_Registro,
    GETDATE() AS Data_Atualizacao
FROM ItensPedidos oi
LEFT JOIN Estoque it ON it.Produtos_ID = oi.ProdutoId
WHERE NOT EXISTS (
    SELECT 1 FROM Estoque WHERE Estoque.Produtos_ID = oi.ProdutoId
)
GROUP BY oi.ProdutoId;









INSERT INTO [dbo].[RequisicaoCompra]
    ([Fornecedor_ID]
    ,[Produto_ID]
    ,[Quantidade]
    ,[Status_Pedido]
    ,[Total_Compra]
    ,[Data_Emissao]
    ,[Data_Registro]
    ,[Data_Atualizacao])
SELECT 
    prx.Id AS Fornecedor_ID,
    pr.Id AS Produto_ID,
    SUM(oi.Quantity_Purchased) AS Quantidade,
    0 AS Status_Pedido, -- Ajuste conforme necessário
    SUM(oi.Item_Price * oi.Quantity_Purchased * 10) AS Total_Compra,
    GETDATE() AS Data_Emissao,
    GETDATE() AS Data_Registro,
    GETDATE() AS Data_Atualizacao
FROM Produtos pr
INNER JOIN ItensPedidos oi ON oi.ProdutoId = pr.Id
INNER JOIN Pedidos od ON od.Id = oi.PedidoId
INNER JOIN Fornecedores prx ON prx.CNPJ ='12.345.678/0001-01'
LEFT JOIN Enderecos en ON en.order_id = od.Order_id
LEFT JOIN RequisicaoCompra rc ON rc.Produto_ID = oi.ProdutoId
WHERE rc.Produto_ID IS NULL
AND oi.Item_Price * oi.Quantity_Purchased * 10 = (
    SELECT MAX(oi2.Item_Price * oi2.Quantity_Purchased * 10)
    FROM ItensPedidos oi2
    WHERE oi2.ProdutoId = pr.Id
)
GROUP BY prx.Id, pr.Id, oi.Item_Price
ORDER BY Total_Compra DESC;




-- Populando notas fiscais


INSERT INTO [dbo].[NotaFiscal]
           ([Pedidos_ID]
           ,[Valor_Total]
           ,[Data_Emissao]
           ,[Data_Registro]
           ,[Data_Atualizacao])
SELECT 
Pe.Id, 
Ck.total_pedido,
Pe.Purchase_Date,
GETDATE(),
GETDATE()
FROM Pedidos Pe 
INNER JOIN Checkout Ck ON Ck.Pedido_id = Pe.Id;


INSERT INTO [dbo].[DespachoMercadorias]
           ([Status_Entrega]
           ,[Data_Liberacao]
           ,[Pedido_Id]
           ,[Transportadora_ID]
           ,[Data_Registro]
           ,[Data_Atualizacao])
SELECT 
    'Pendente',
    GETDATE(),
    pe.Id,
    tr.Id,
    pe.Data_Registro,
    pe.Data_Atualizacao
FROM Pedidos pe
INNER JOIN Transportadoras tr ON tr.Id = 1
WHERE NOT EXISTS (
    SELECT 1
    FROM [dbo].[DespachoMercadorias] dm
    WHERE dm.Pedido_Id = pe.Id
);


