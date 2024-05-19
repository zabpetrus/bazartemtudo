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
	[order_ID] INT PRIMARY KEY IDENTITY(1,1) NOT NULL, --id exclusivo (controle interno) do pedido
	[client_id] INT NOT NULL, -- id do cliente (controle interno)
	[order_def_id] INT NOT NULL, --id do cliente (vem do marketplace - controle externo)
    [order_purchase_date] DATETIME2 NOT NULL, -- data da compra
    [order_payments_date] DATETIME2 NOT NULL, -- data do pagamento
	[order_ship_city] VARCHAR(50) NOT NULL, -- cidade de despacho do pedido
    [order_ship_state] VARCHAR(50) NOT NULL,-- estado de despacho do pedido
    [order_ship_postal_code] VARCHAR(10) NOT NULL, -- codigo postal de despacho do pedido
	[order_ship_address_1] varchar(100) NULL,
	[order_ship_address_2] varchar(100) NULL,
	[order_ship_address_3] varchar(100) NULL,
    [order_ship_country] VARCHAR(30) NOT NULL,	-- pais de despacho do pedido
	[order_currency] VARCHAR(10) NOT NULL, -- moeda corrente do pedido
	[order_ship_service_level] VARCHAR(20) DEFAULT 'Standard Shipping' CHECK ([order_ship_service_level] IN ('Standard Shipping', 'Express Shipping', 'Priority Shipping')),
	[order_status_delivery] VARCHAR(20) NOT NULL DEFAULT 'Processing' CHECK ([order_status_delivery] IN ('Processing', 'Shipped', 'Delivered', 'In Transit', 'Returned'))
);


DROP TABLE IF EXISTS [OrderItems];

CREATE TABLE [dbo].[OrderItems] (
	[oi_order_ID] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[order_id] INT NOT NULL, -- OrderID vindo de Pedidos
	[product_id] INT NOT NULL, -- ProductID vindo de Produtos
	[oi_order_item_id] INT NOT NULL, -- Ordem ID da Fonte
	[oi_product_price] DECIMAL(18,2) NOT NULL, -- preco
	[oi_quantity_purchased] INT NOT NULL, -- quantidade 
	[oi_item_status] VARCHAR(20) NOT NULL DEFAULT 'Processing' CHECK ([oi_item_status] IN ('Processing', 'Shipped', 'Delivered', 'In Transit', 'Returned')) -- Se está disponivel
);

-- TABELA DE REQUISICAO DE COMPRA

DROP TABLE IF EXISTS [Purchase_Requests];

CREATE TABLE [dbo].[Purchase_Requests](
	[pr_id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[product_id] INT NOT NULL,-- id do produto registrado
	[pr_supply] INT NOT NULL, -- id do fornecedor. Neste caso,será um forncedor generalista tipo atacadão
	[pr_quantity] INT NOT NULL, -- quantidade do produto
	[pr_unit_price] DECIMAL(18,2) NOT NULL, -- preco individual do produto
	[pr_total_price] DECIMAL (18,2) NOT NULL, -- o custo total da compra
	[pr_purchase] DATETIME2 NOT NULL, -- data da requisicao
	[pr_backorder] BIT DEFAULT 0 --termo em ingles que indica que um produto está "aguardando chegada" 
);

-- TABELA ESTOQUE
DROP TABLE IF EXISTS [Internal_Storage];

CREATE TABLE [dbo].[Internal_Storage] (
	[is_id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL, -- id de controle interno do estoque
	[product_id] INT NOT NULL, -- id do produto
	[is_actual_qte] INT DEFAULT 0 NOT NULL, -- o que é comprado
	[is_minimal_qte] INT DEFAULT 0 NOT NULL,--vem dos pedidos: relação à carga. É atualizado quando vem a carga
);

-- TABELA FORNECEDORES

DROP TABLE IF EXISTS [Suppliers];

CREATE TABLE [dbo].[Suppliers] (
	[s_id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL, -- id do fornecedor
	[s_name] VARCHAR(50) NOT NULL, -- Nome Fantasia do Fornecedor
	[s_cnpj] VARCHAR(30) NOT NULL UNIQUE, -- Cnpj do Fornecedor
	[s_email] VARCHAR(50) NOT NULL, -- Email de contato do Fornecedor. A ordem de serviço será enviada para o email designado
	[s_city] VARCHAR(50) NOT NULL, -- Cidade do Fornecedor
	[s_country] VARCHAR(30) NOT NULL -- País do Fornecedor
);








ALTER TABLE Orders ADD CONSTRAINT FK_OR_CLI FOREIGN KEY (client_id) REFERENCES Clients ( client_id ) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE Internal_Storage ADD CONSTRAINT FK_IS_PROD FOREIGN KEY (product_id) REFERENCES Products (product_id) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE OrderItems ADD CONSTRAINT FK_OI_ORD FOREIGN KEY (order_id) REFERENCES Orders (order_ID) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE OrderItems ADD CONSTRAINT FK_OI_PROD FOREIGN KEY (product_id) REFERENCES Products (product_id) ON DELETE CASCADE ON UPDATE CASCADE;


GO






