USE [BazarDB];
GO

-- Inserindo Fornecedores

INSERT INTO [dbo].[Suppliers] (
[s_name], [s_cnpj],	[s_email], 	[s_city], [s_country]) 
SELECT 'Atacadao Auto Market', '99.250.886/0001-99', 'atacadaoauto@comercial.com', 'Sao Paulo', 'BR'
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[Suppliers] WHERE [s_cnpj] = '99.250.886/0001-99');

INSERT INTO [dbo].[Suppliers] (
[s_name], [s_cnpj],	[s_email], 	[s_city], [s_country]) 
SELECT 'AlibabaDropship', '43.372.061/0001-92', 'alibabadrophopcommerce@marketrio.com', 'Rio de Janeiro','USA'
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[Suppliers] WHERE [s_cnpj] = '43.372.061/0001-92');

INSERT INTO [dbo].[Suppliers] (
[s_name], [s_cnpj],	[s_email], 	[s_city], [s_country]) 
SELECT 'Muambeiros Atacadao', '75.590.367/0001-01', 'commerce@muambeirosatacadao.com.br', 'Brasilia', 'BR'
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[Suppliers] WHERE [s_cnpj] = '75.590.367/0001-01');

INSERT INTO [dbo].[Suppliers] (
[s_name], [s_cnpj],	[s_email], 	[s_city], [s_country]) 
SELECT 'Emporio Tabajara', '57.457.143/0001-44', 'emporiotabajara@marketcommerce.com', 'Salvador', 'BR'
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[Suppliers] WHERE [s_cnpj] = '57.457.143/0001-44');



-- Inserindo atraves da carga

INSERT INTO [dbo].[Clients]
           ([client_name] ,[client_email] ,[client_cpf],[client_phone_number])

	SELECT DISTINCT 
	Ca.buyer_name, Ca.buyer_email, 	Ca.cpf, Ca.buyer_phone_number 
	FROM Carga Ca  
	LEFT JOIN [Clients] ON Clients.client_cpf = Ca.cpf 
	WHERE NOT EXISTS (  SELECT 1  FROM [Clients] Cl  WHERE Cl.client_cpf = Ca.cpf );

	PRINT 'Clientes populados';



INSERT INTO [dbo].[Products]
           ([product_name] ,[product_sku] ,[product_upc],[product_item_price])

			SELECT DISTINCT Ca.product_name, ca.sku, ca.upc,ca.item_price FROM Carga Ca
			LEFT JOIN Products ON Products.product_upc = Ca.upc WHERE NOT EXISTS 
			(SELECT 1 FROM Products WHERE Products.product_upc = Ca.upc );

		PRINT 'Produtos populado';



INSERT INTO [dbo].[Orders]
	([client_id]
	,[order_def_id]
	,[order_purchase_date]
	,[order_payments_date]
	,[order_ship_city]
	,[order_ship_state]
	,[order_ship_postal_code]
	,[order_ship_address_1] 
	,[order_ship_address_2]
	,[order_ship_address_3]
	,[order_ship_country]
	,[order_currency]
	,[order_ship_service_level])

	SELECT DISTINCT
	Clients.client_id,
	carga.order_id AS order_def_id,
	carga.purchase_date,
	carga.payments_date,
	carga.ship_city,
	carga.ship_state,
	carga.ship_postal_code,
	order_ship_address_1,
	order_ship_address_2,
	order_ship_address_3,
	carga.ship_country,
	carga.currency,
	carga.ship_service_level
	FROM Carga 
	LEFT JOIN Clients ON Clients.client_cpf = Carga.cpf
	LEFT JOIN Orders ON Orders.order_id = Carga.order_id
	WHERE NOT EXISTS (SELECT 1 FROM Orders WHERE Orders.order_def_id = Carga.order_id );

	PRINT 'Orders populado (Pedidos)';


	INSERT INTO [dbo].[OrderItems]
    ([order_id]
    ,[product_id]
    ,[oi_order_item_id]
    ,[oi_product_price]
    ,[oi_quantity_purchased]
    )

	SELECT 
	od.order_ID,
	pr.product_id,
	ca.order_item_id,
	pr.product_item_price,
	ca.quantity_purchased
	FROM Carga ca 
	LEFT JOIN  Orders od ON od.order_def_id = ca.order_id
	LEFT JOIN Products pr ON pr.product_upc  = ca.upc 
	LEFT JOIN OrderItems oi ON oi.order_id = ca.order_item_id AND oi.product_id = pr.product_id
	WHERE NOT EXISTS (
    SELECT 1
    FROM OrderItems oi 
    WHERE oi.order_id = od.order_ID 
    AND oi.product_id = pr.product_id
	);

	PRINT 'OrdersItens populados (Itens dos pedidos)';


INSERT INTO [dbo].[Internal_Storage]
           ([product_id]
           ,[is_actual_qte]
           ,[is_minimal_qte])
			SELECT DISTINCT 
			oi.product_id, 
			0 AS qte,
			SUM( oi.oi_quantity_purchased ) AS minimal_qte
			FROM orderitems oi 
			LEFT JOIN
			Internal_Storage it ON it.product_id = oi.product_id
				WHERE NOT EXISTS (
				SELECT 1 FROM internal_storage WHERE internal_storage.product_id = oi.product_id )
				GROUP BY oi.product_id;

	PRINT 'Internal Storage populado (Estoque)';




INSERT INTO [dbo].[Purchase_Requests]
    (
	[product_id], 
	[pr_supply],
	[pr_quantity],
	[pr_unit_price],
	[pr_total_price],
	[pr_purchase],
	[pr_backorder])

SELECT 
    pr.product_id,
	SUM(10 * oi.oi_quantity_purchased) AS oiqte,
	oi.oi_product_price,
	SUM(oi.oi_product_price * oi.oi_quantity_purchased * 10) AS Total,
	(SELECT TOP(1) su.s_id FROM Suppliers su INNER JOIN Orders oi ON oi.order_ship_state = su.s_city OR oi.order_ship_country = su.s_country) AS MinSupplierID,
	GETDATE() AS CurrentTime,
	0
	FROM products pr
	LEFT JOIN OrderItems oi ON oi.product_id = pr.product_id
    INNER JOIN orders od ON od.order_ID = oi.order_id
	LEFT JOIN purchase_requests prx ON prx.product_id = oi.product_id
	WHERE NOT EXISTS (
    SELECT 1 FROM purchase_requests WHERE purchase_requests.product_id = oi.product_id
)
GROUP BY pr.product_id,oi_product_price
ORDER BY Total DESC;
	


PRINT 'Purchase_Requests Populado (Requisicao de compra)';