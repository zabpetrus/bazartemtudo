USE [BazarDB];

GO;

IF OBJECT_ID('PopularTabelas', 'P') IS NOT NULL
DROP PROCEDURE PopularTabelas;
GO;

CREATE PROCEDURE PopularTabelas
AS
BEGIN
		-- Inserindo em Produtos baseado no select de carga e verificando se não está duplicado
-- Inserindo Fornecedores

INSERT INTO Fornecedores(
forn_name, forn_cnpj,	forn_email, forn_cidade, forn_pais) 
SELECT 'Atacadao Auto Market', '99.250.886/0001-99', 'atacadaoauto@comercial.com', 'Sao Paulo', 'BR'
WHERE NOT EXISTS (SELECT 1 FROM Fornecedores WHERE forn_cnpj = '99.250.886/0001-99');

INSERT INTO Fornecedores (
forn_name, forn_cnpj,	forn_email, forn_cidade, forn_pais) 
SELECT 'AlibabaDropship', '43.372.061/0001-92', 'alibabadrophopcommerce@marketrio.com', 'Rio de Janeiro','USA'
WHERE NOT EXISTS (SELECT 1 FROM Fornecedores WHERE forn_cnpj = '43.372.061/0001-92');

INSERT INTO Fornecedores (
forn_name, forn_cnpj,	forn_email, forn_cidade, forn_pais) 
SELECT 'Muambeiros Atacadao', '75.590.367/0001-01', 'commerce@muambeirosatacadao.com.br', 'Brasilia', 'BR'
WHERE NOT EXISTS (SELECT 1 FROM Fornecedores WHERE forn_cnpj = '75.590.367/0001-01');

INSERT INTO Fornecedores (
forn_name, forn_cnpj,	forn_email, forn_cidade, forn_pais) 
SELECT 'Emporio Tabajara', '57.457.143/0001-44', 'emporiotabajara@marketcommerce.com', 'Salvador', 'BR'
WHERE NOT EXISTS (SELECT 1 FROM Fornecedores WHERE forn_cnpj = '57.457.143/0001-44');

PRINT 'Fornecedores populados';


-- Inserindo em Transportadoras
INSERT INTO [dbo].[Transportadoras]
           ([Nome_Transportadora]
           ,[CNPJ_Transportadora]
           ,[Tipo_Servico]
           ,[Custo_Frete])
     VALUES
           ('America Transportes', '97.064.519/0001-75', 'Padrao', 25.99),
           ('Rupiao Entregas Brasil LTDA', '01.503.315/0001-14', 'Padrao', 19.99),
		   ('Calango Express', '46.458.091/0001-04', 'Expressa', 55.99),
		   ('Guanabara Fretes e Entregas LTDA', '17.342.627/0001-23', 'Expressa', 45.99),
		   ('Ronaldo Entregas Express', '49.623.352/0001-92', 'Expressa', 60.99);

PRINT 'Transportadoras populadas';


-- Inserindo atraves da carga

INSERT INTO [dbo].[Clientes]
           (cliente_name ,cliente_email ,cliente_cpf,cliente_phone_number)

	SELECT DISTINCT 
	Ca.buyer_name, Ca.buyer_email, 	Ca.cpf, Ca.buyer_phone_number 
	FROM Carga Ca  
	LEFT JOIN [Clientes] ON Clientes.cliente_cpf = Ca.cpf 
	WHERE NOT EXISTS (  SELECT 1  FROM [Clientes] Cl  WHERE Cl.cliente_cpf = Ca.cpf );

	PRINT 'Clientes populados';



INSERT INTO [dbo].[Produtos]
           (produto_name ,produto_sku ,produto_upc,produto_item_price)

			SELECT DISTINCT Ca.product_name, ca.sku, ca.upc,ca.item_price FROM Carga Ca
			LEFT JOIN Produtos ON Produtos.produto_upc = Ca.upc WHERE NOT EXISTS 
			(SELECT 1 FROM Produtos WHERE Produtos.produto_upc = Ca.upc );

		PRINT 'Produtos populado';



INSERT INTO [dbo].[Pedidos]
    ([pedido_cliente_id]
    ,[pedido_def_id]
    ,[pedido_purchase_date]
    ,[pedido_payments_date]
    ,[pedido_ship_city]
    ,[pedido_ship_state]
    ,[pedido_ship_postal_code]
    ,[pedido_ship_address_1]
    ,[pedido_ship_address_2]
    ,[pedido_ship_address_3]
    ,[pedido_ship_country]
    ,[pedido_currency]
    ,[pedido_ship_service_level])
SELECT DISTINCT
    Clientes.cliente_id AS pedido_cliente_id,
    Carga.order_id AS pedido_def_id,
    Carga.purchase_date AS pedido_purchase_date,
    Carga.payments_date AS pedido_payments_date,
    Carga.ship_city AS pedido_ship_city,
    Carga.ship_state AS pedido_ship_state,
    Carga.ship_postal_code AS pedido_ship_postal_code,
    Carga.ship_address_1 AS pedido_ship_address_1,
    Carga.ship_address_2 AS pedido_ship_address_2,
    Carga.ship_address_3 AS pedido_ship_address_3,
    Carga.ship_country AS pedido_ship_country,
    Carga.currency AS pedido_currency,
    Carga.ship_service_level AS pedido_ship_service_level
FROM Carga
LEFT JOIN Clientes ON Clientes.cliente_cpf = Carga.cpf
LEFT JOIN Pedidos ON Pedidos.pedido_def_id = Carga.order_id
WHERE Pedidos.pedido_def_id IS NULL;

PRINT 'Orders populado (Pedidos)';



INSERT INTO [dbo].[ItensPedidos]
    ([ip_pedido_id]
    ,[ip_produto_id]
    ,[ip_pedido_item_id]
    ,[ip_produto_price]
    ,[ip_quantity_purchased]
    ,[ip_item_status])
SELECT 
    od.pedido_ID AS ip_pedido_id,
    pr.produto_id AS ip_produto_id,
    ca.order_item_id AS ip_pedido_item_id,
    pr.produto_item_price AS ip_produto_price,
    ca.quantity_purchased AS ip_quantity_purchased,
    'Processing' AS ip_item_status -- Definindo o status padrão para 'Processing'
FROM Carga ca
LEFT JOIN Pedidos od ON od.pedido_def_id= ca.order_id
LEFT JOIN Produtos pr ON pr.produto_upc = ca.upc
LEFT JOIN ItensPedidos oi ON oi.ip_pedido_id = ca.order_item_id AND oi.ip_pedido_id = pr.produto_id
WHERE NOT EXISTS (
    SELECT 1
    FROM ItensPedidos ip
    WHERE ip.ip_pedido_id = od.pedido_ID 
    AND ip.ip_produto_id = pr.produto_id
);

	PRINT 'OrdersItens populados (Itens dos pedidos)';


INSERT INTO [dbo].[Estoque]
           ([Produto_id]
           ,[is_actual_qte]
           ,[is_minimal_qte])
			SELECT DISTINCT 
			oi.ip_produto_id, 
			0 AS qte,
			SUM( oi.ip_quantity_purchased ) AS minimal_qte
			FROM ItensPedidos oi 
			LEFT JOIN
			Estoque it ON it.Produto_id = oi.ip_produto_id
				WHERE NOT EXISTS (
				SELECT 1 FROM Estoque WHERE Estoque.Produto_id = oi.ip_produto_id )
				GROUP BY oi.ip_produto_id;

	PRINT 'Internal Storage populado (Estoque)';




INSERT INTO [dbo].[RequisicoesCompra]
    ([pr_produto_id]
    ,[pr_fornecedor_id]
    ,[pr_quantidade]
    ,[pr_preco_unitario]
    ,[pr_preco_total]
    ,[pr_data_requisicao]
    ,[pr_status_pedido])
SELECT 
    pr.produto_id AS pr_produto_id,
    MAX(prx.forn_id) AS pr_fornecedor_id,
    SUM(oi.ip_quantity_purchased) AS pr_quantidade,
    oi.ip_produto_price AS pr_preco_unitario,
    SUM(oi.ip_produto_price * oi.ip_quantity_purchased * 10) AS pr_preco_total,
    GETDATE() AS pr_data_requisicao,
    0 AS pr_status_pedido
FROM Produtos pr
INNER JOIN ItensPedidos oi ON oi.ip_produto_id = pr.produto_id
INNER JOIN Pedidos od ON od.pedido_ID = oi.ip_pedido_id
LEFT JOIN Fornecedores prx ON prx.forn_name = od.pedido_ship_city
LEFT JOIN RequisicoesCompra rc ON rc.pr_produto_id = oi.ip_produto_id
WHERE rc.pr_produto_id IS NULL
AND oi.ip_produto_price * oi.ip_quantity_purchased * 10 = (
    SELECT MAX(oi2.ip_produto_price * oi2.ip_quantity_purchased * 10)
    FROM ItensPedidos oi2
    WHERE oi2.ip_produto_id = pr.produto_id
)
GROUP BY pr.produto_id, oi.ip_produto_price
ORDER BY pr_preco_total DESC;



PRINT 'Purchase_Requests Populado (Requisicao de compra)';

-- Populando notas fiscais

INSERT INTO [dbo].[NotasFiscais]
           ([Pedido_ID]
           ,[Valor_Total]
           ,[Data_Emissao])
    
SELECT 
Pe.pedido_ID, 
Ck.total_pedido,
GETDATE() AS CurrentTime
FROM Pedidos Pe 
INNER JOIN Checkout Ck ON Ck.Pedido_id = Pe.pedido_ID ;


		


END;