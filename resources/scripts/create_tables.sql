USE [BazarDB];
GO

IF EXISTS (
    SELECT 1
    FROM information_schema.table_constraints
    WHERE table_name = 'Orders' 
    AND constraint_name = 'FK_OR_CLI'
)
BEGIN
    ALTER TABLE Orders
    DROP CONSTRAINT FK_OR_CLI;
END;



IF EXISTS (
    SELECT 1
    FROM information_schema.table_constraints
    WHERE table_name = 'Internal_Storage' 
    AND constraint_name = 'FK_IS_PROD'
)
BEGIN
    ALTER TABLE Internal_Storage
    DROP CONSTRAINT FK_IS_PROD;
END;


IF EXISTS (
	SELECT 1 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
	WHERE TABLE_NAME = 'OrderItems'
	AND CONSTRAINT_NAME = 'FK_OI_ORD'
)
BEGIN
	ALTER TABLE OrderItems DROP CONSTRAINT FK_OI_ORD;
END



IF EXISTS (
	SELECT 1 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
	WHERE TABLE_NAME = 'OrderItems'
	AND CONSTRAINT_NAME = 'FK_OI_PROD'
)
BEGIN
	ALTER TABLE OrderItems DROP CONSTRAINT FK_OI_PROD;
END



DROP TABLE IF EXISTS [Clients];

CREATE TABLE [dbo].[Clients](
	[client_id] [INT] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[client_name] [varchar](80) NOT NULL,
	[client_email] [varchar](50) NOT NULL,
	[client_cpf] [varchar](30) NOT NULL,
	[client_phone_number] [varchar](30) NOT NULL	
);


DROP TABLE IF EXISTS [Products];

CREATE TABLE [dbo].[Products](
	[product_id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[product_name] VARCHAR(150) NOT NULL,
	[product_sku] VARCHAR(50) NOT NULL,
    [product_upc] VARCHAR(50) NOT NULL,
	[product_item_price] DECIMAL(18,2) NOT NULL,   
);


DROP TABLE IF EXISTS [Orders];

CREATE TABLE [dbo].[Orders](
	[order_ID] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[client_id] INT NOT NULL,
	[order_def_id] INT NOT NULL,    -- vem da loja
    [order_purchase_date] DATETIME2 NOT NULL,
    [order_payments_date] DATETIME2 NOT NULL,
	[order_ship_city] VARCHAR(50) NOT NULL,
    [order_ship_state] VARCHAR(50) NOT NULL,
    [order_ship_postal_code] VARCHAR(10) NOT NULL,
    [order_ship_country] VARCHAR(30) NOT NULL,	
	[order_currency] VARCHAR(10) NOT NULL,
	[order_ship_service_level] VARCHAR(30) NOT NULL,
	[order_status_delivery] INT NOT NULL DEFAULT 0
);


DROP TABLE IF EXISTS [OrderItems];

CREATE TABLE [dbo].[OrderItems] (
	[oi_order_ID] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[order_id] INT NOT NULL, -- OrderID vindo de Pedidos
	[product_id] INT NOT NULL, -- ProductID vindo de Produtos
	[oi_order_item_id] INT NOT NULL, -- Ordem ID da Fonte
	[oi_product_price] DECIMAL(18,2) NOT NULL, -- preco
	[oi_quantity_purchased] INT NOT NULL, -- quantidade 
	[oi_item_status] INT DEFAULT 0 NOT NULL -- Se está disponivel
);

DROP TABLE IF EXISTS [Purchase_Requests];

CREATE TABLE [dbo].[Purchase_Requests](
	[pr_id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[product_id] INT NOT NULL,
	[pr_supply] INT NOT NULL,
	[pr_quantity] INT NOT NULL,
	[pr_unit_price] DECIMAL(18,2) NOT NULL,
	[pr_total_price] DECIMAL (18,2) NOT NULL,
	[pr_purchase] DATETIME2 NOT NULL	
);


DROP TABLE IF EXISTS [Internal_Storage];

CREATE TABLE [dbo].[Internal_Storage] (
	[is_id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[product_id] INT NOT NULL,
	[is_actual_qte] INT DEFAULT 0 NOT NULL,
	[is_minimal_qte] INT DEFAULT 0 NOT NULL,
);

DROP TABLE IF EXISTS [Suppliers];

CREATE TABLE [dbo].[Suppliers] (
	[s_id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[s_name] VARCHAR(50) NOT NULL,
	[s_cnpj] VARCHAR(30) NOT NULL UNIQUE,
	[s_email] VARCHAR(50) NOT NULL,
	[s_city] VARCHAR(50) NOT NULL,
	[s_country] VARCHAR(30) NOT NULL
);








ALTER TABLE Orders ADD CONSTRAINT FK_OR_CLI FOREIGN KEY (client_id) REFERENCES Clients ( client_id ) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE Internal_Storage ADD CONSTRAINT FK_IS_PROD FOREIGN KEY (product_id) REFERENCES Products (product_id) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE OrderItems ADD CONSTRAINT FK_OI_ORD FOREIGN KEY (order_id) REFERENCES Orders (order_ID) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE OrderItems ADD CONSTRAINT FK_OI_PROD FOREIGN KEY (product_id) REFERENCES Products (product_id) ON DELETE CASCADE ON UPDATE CASCADE;


GO






