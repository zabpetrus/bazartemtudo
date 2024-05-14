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
    oi.product_id,
    SUM(oi.oi_quantity_purchased * oi.oi_product_price) AS KAS

FROM 
    OrderItems oi
INNER JOIN 
    Products pr ON oi.product_id = pr.product_id  
INNER JOIN
	Orders od ON od.order_ID = oi.oi_order_ID
INNER JOIN
	Suppliers su ON su.s_country = od.order_ship_country
GROUP BY 
    oi.product_id
ORDER BY 
    oi.product_id;
