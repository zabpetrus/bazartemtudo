USE [BazarDB];
GO

-- Inserindo Fornecedores



-- Inserção 1
INSERT INTO [dbo].[Fornecedores]
           ([Nome_Fornecedor]
           ,[CNPJ]
           ,[Endereco_ID]
           ,[Telefone]
           ,[Email]
           ,[Website]
           ,[Data_Registro]
           ,[Data_Atualizacao])
     
	 SELECT 'Fornecedor A', '12.345.678/0001-01', 1, '(11) 1234-5678', 'fornecedor_a@example.com', 'www.fornecedora.com', GETDATE(), GETDATE()
	 WHERE NOT EXISTS ( SELECT 1 FROM [dbo].[Fornecedores] f  WHERE f.CNPJ = '12.345.678/0001-01' );

-- Inserção 2
INSERT INTO [dbo].[Fornecedores]
           ([Nome_Fornecedor]
           ,[CNPJ]
           ,[Endereco_ID]
           ,[Telefone]
           ,[Email]
           ,[Website]
           ,[Data_Registro]
           ,[Data_Atualizacao])
     SELECT  'Fornecedor B', '98.765.432/0001-02', 2, '(21) 9876-5432', 'fornecedor_b@example.com', 'www.fornecedorb.com', GETDATE(), GETDATE()
		   WHERE NOT EXISTS ( SELECT 1  FROM [dbo].[Fornecedores] f  WHERE f.CNPJ = '98.765.432/0001-02' );

-- Inserção 3
INSERT INTO [dbo].[Fornecedores]
           ([Nome_Fornecedor]
           ,[CNPJ]
           ,[Endereco_ID]
           ,[Telefone]
           ,[Email]
           ,[Website]
           ,[Data_Registro]
           ,[Data_Atualizacao])
     SELECT  'Fornecedor C', '11.222.333/0001-03', 3, '(31) 1122-3344', 'fornecedor_c@example.com', 'www.fornecedorc.com', GETDATE(), GETDATE()
	 WHERE NOT EXISTS ( SELECT 1  FROM [dbo].[Fornecedores] f  WHERE f.CNPJ = '11.222.333/0001-03' ); 

-- Inserção 4
INSERT INTO [dbo].[Fornecedores]
           ([Nome_Fornecedor]
           ,[CNPJ]
           ,[Endereco_ID]
           ,[Telefone]
           ,[Email]
           ,[Website]
           ,[Data_Registro]
           ,[Data_Atualizacao])
     SELECT 'Fornecedor D', '44.555.666/0001-04', 4, '(41) 4455-6666', 'fornecedor_d@example.com', 'www.fornecedord.com', GETDATE(), GETDATE()
	  WHERE NOT EXISTS ( SELECT 1  FROM [dbo].[Fornecedores] f  WHERE f.CNPJ = '44.555.666/0001-04' ); 

-- Inserção 5
INSERT INTO [dbo].[Fornecedores]
           ([Nome_Fornecedor]
           ,[CNPJ]
           ,[Endereco_ID]
           ,[Telefone]
           ,[Email]
           ,[Website]
           ,[Data_Registro]
           ,[Data_Atualizacao])
     SELECT 'Fornecedor E', '77.888.999/0001-05', 5, '(51) 7788-9999', 'fornecedor_e@example.com', 'www.fornecedore.com', GETDATE(), GETDATE()
	 WHERE NOT EXISTS ( SELECT 1  FROM [dbo].[Fornecedores] f  WHERE f.CNPJ = '77.888.999/0001-05' ); 


PRINT 'Fornecedores populados';


USE [BazarDB]
GO

-- Inserção 1
INSERT INTO [dbo].[Transportadoras]
           ([NomeTransportadora]
           ,[CNPJ]
           ,[TipoServico]
           ,[CustoFrete]
           ,[Data_Registro]
           ,[Data_Atualizacao])
     VALUES
           ('Transportadora A', '11.222.333/0001-01', 1, 50.00, GETDATE(), GETDATE());

-- Inserção 2
INSERT INTO [dbo].[Transportadoras]
           ([NomeTransportadora]
           ,[CNPJ]
           ,[TipoServico]
           ,[CustoFrete]
           ,[Data_Registro]
           ,[Data_Atualizacao])
  
     VALUES
           ('Transportadora B', '22.333.444/0001-02', 2, 75.00, GETDATE(), GETDATE());

-- Inserção 3
INSERT INTO [dbo].[Transportadoras]
           ([NomeTransportadora]
           ,[CNPJ]
           ,[TipoServico]
           ,[CustoFrete]
           ,[Data_Registro]
           ,[Data_Atualizacao]
)     VALUES
           ('Transportadora C', '33.444.555/0001-03', 1, 60.00, GETDATE(), GETDATE());

-- Inserção 4
INSERT INTO [dbo].[Transportadoras]
           ([NomeTransportadora]
           ,[CNPJ]
           ,[TipoServico]
           ,[CustoFrete]
           ,[Data_Registro]
           ,[Data_Atualizacao]
)     VALUES
           ('Transportadora D', '44.555.666/0001-04', 3, 90.00, GETDATE(), GETDATE());

-- Inserção 5
INSERT INTO [dbo].[Transportadoras]
           ([NomeTransportadora]
           ,[CNPJ]
           ,[TipoServico]
           ,[CustoFrete]
           ,[Data_Registro]
           ,[Data_Atualizacao]
)     VALUES
           ('Transportadora E', '55.666.777/0001-05', 2, 80.00, GETDATE(), GETDATE());

GO



-- Inserindo atraves da carga

INSERT INTO [dbo].[Clientes]
(Nome, Email, CPF, Phone, Data_Registro, Data_Atualizacao)
SELECT DISTINCT 
Ca.buyer_name, Ca.buyer_email, Ca.cpf, Ca.buyer_phone_number, GETDATE(), GETDATE()
FROM Carga Ca
LEFT JOIN [Clientes] Cl ON Cl.CPF = Ca.cpf
WHERE Cl.CPF IS NULL;

PRINT 'Clientes populados';



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


PRINT 'Enderecos populados';


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

PRINT 'Tabela Pedidos populada';




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
    pe.Id,
	pr.Id,
	ca.order_item_id,
	ca.item_price,
	ca.quantity_purchased,
	GETDATE(),
	GETDATE()
	FROM Pedidos pe
	INNER JOIN Carga Ca ON Ca.order_id = pe.Order_id
	INNER JOIN Produtos pr ON pr.UPC = Ca.upc
	INNER JOIN ItensPedidos ip ON ip.PedidoId = pe.Id AND ip.ProdutoId = pr.Id;

PRINT 'OrdersItens populados (Itens dos pedidos)';





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

PRINT 'Internal Storage populado (Estoque)';








INSERT INTO [dbo].[RequisicaoCompra]
    ([Fornecedor_ID]
    ,[Produto_ID]
    ,[Quantidade]
    ,[Status_Pedido]
    ,[Total_Compra]
    ,[Data_Emissao]
    ,[FornecedorId]
    ,[ProdutoId]
    ,[Data_Registro]
    ,[Data_Atualizacao])
SELECT 
    MAX(prx.Id) AS Fornecedor_ID,
    pr.Id AS Produto_ID,
    SUM(oi.Quantity_Purchased) AS Quantidade,
    0 AS Status_Pedido, -- Ajuste conforme necessário
    SUM(oi.Item_Price * oi.Quantity_Purchased * 10) AS Total_Compra,
    GETDATE() AS Data_Emissao,
    MAX(prx.Id) AS FornecedorId, -- Certifique-se que este é o campo correto
    pr.Id AS ProdutoId,
    GETDATE() AS Data_Registro,
    GETDATE() AS Data_Atualizacao
FROM Produtos pr
INNER JOIN ItensPedidos oi ON oi.ProdutoId = pr.Id
INNER JOIN Pedidos od ON od.Id = oi.PedidoId
LEFT JOIN Enderecos en ON en.order_id = od.Order_id
LEFT JOIN Fornecedores prx ON prx.Endereco_ID = en.Id
LEFT JOIN RequisicaoCompra rc ON rc.Produto_ID = oi.ProdutoId
WHERE rc.Produto_ID IS NULL
AND oi.Item_Price * oi.Quantity_Purchased * 10 = (
    SELECT MAX(oi2.Item_Price * oi2.Quantity_Purchased * 10)
    FROM ItensPedidos oi2
    WHERE oi2.ProdutoId = pr.Id
)
GROUP BY pr.Id, oi.Item_Price
ORDER BY Total_Compra DESC;

PRINT 'Tabela RequisicaoCompra populada';



PRINT 'Purchase_Requests Populado (Requisicao de compra)';

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



