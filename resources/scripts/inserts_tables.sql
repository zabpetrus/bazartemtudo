USE [BazarDB];
GO


INSERT INTO [dbo].[Clients]
           ([client_name] ,[client_email] ,[client_cpf],[client_phone_number])

	SELECT DISTINCT 
	Ca.buyer_name, Ca.buyer_email, 	Ca.cpf, Ca.buyer_phone_number 
	FROM Carga Ca  
	LEFT JOIN [Clients] ON Clients.client_cpf = Ca.cpf 
	WHERE NOT EXISTS (  SELECT 1  FROM [Clients] Cl  WHERE Cl.client_cpf = Ca.cpf );


INSERT INTO [dbo].[Products]
           ([product_name] ,[product_sku] ,[product_upc],[product_item_price])

			SELECT DISTINCT Ca.product_name, ca.sku, ca.upc,ca.item_price FROM Carga Ca
			LEFT JOIN Products ON Products.product_upc = Ca.upc WHERE NOT EXISTS 
			(SELECT 1 FROM Products WHERE Products.product_upc = Ca.upc );



INSERT INTO [dbo].[Orders]
           ([client_id]
           ,[order_id]
           ,[order_purchase_date]
           ,[order_payments_date]
           ,[order_ship_city]
           ,[order_ship_state]
           ,[order_ship_postal_code]
           ,[order_ship_country]
           ,[order_currency]
           ,[order_ship_service_level]
           )
		   SELECT DISTINCT
			(SELECT client_id FROM Clients WHERE Clients.client_cpf = Ca.cpf) AS client_id,
			ca.order_id,
			ca.purchase_date,
			ca.payments_date,
			ca.ship_city,
			ca.ship_state,
			ca.ship_postal_code,
			ca.ship_country,
			ca.currency,
			ca.ship_service_level
		FROM Carga Ca
		WHERE NOT EXISTS (
			SELECT 1
			FROM [Orders] Ords
			WHERE Ords.order_id = Ca.order_id
			AND Ords.client_id = (SELECT client_id FROM Clients WHERE Clients.client_cpf = Ca.cpf)
);








GO