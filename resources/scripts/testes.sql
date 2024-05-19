/*
[pr_id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[product_id] INT NOT NULL,
	[pr_supply] INT NOT NULL,
	[pr_quantity] INT NOT NULL,
	[pr_unit_price] DECIMAL(18,2) NOT NULL,
	[pr_total_price] DECIMAL (18,2) NOT NULL,
	[pr_purchase] DATETIME2 NOT NULL	
*/

SELECT 
    pr.product_id,
	SUM(10 * oi.oi_quantity_purchased) AS oiqte,
	oi.oi_product_price,
	SUM(oi.oi_product_price * oi.oi_quantity_purchased * 10) AS Total,
	(SELECT TOP(1) su.s_id FROM Suppliers su INNER JOIN Orders oi ON oi.order_ship_state = su.s_city OR oi.order_ship_country = su.s_country) AS MinSupplierID,
	GETDATE() AS CurrentTime
	FROM products pr
	LEFT JOIN OrderItems oi ON oi.product_id = pr.product_id
    INNER JOIN orders od ON od.order_ID = oi.order_id
	LEFT JOIN purchase_requests prx ON prx.product_id = oi.product_id
	WHERE NOT EXISTS (
    SELECT 1 FROM purchase_requests WHERE purchase_requests.product_id = oi.product_id
)
GROUP BY pr.product_id,oi_product_price
ORDER BY Total DESC;
	
