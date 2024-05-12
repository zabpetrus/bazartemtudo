USE [BazarDB];
GO

IF OBJECT_ID('dbo.Carga', 'U') IS NOT NULL
    DROP TABLE dbo.Carga;
GO

CREATE TABLE Carga(
    order_id INT NOT NULL,
    order_item_id INT NOT NULL,
    purchase_date DATETIME2 NOT NULL,
    payments_date DATETIME2 NOT NULL,
    buyer_email VARCHAR(50) NOT NULL,
    buyer_name VARCHAR(80) NOT NULL,
    cpf VARCHAR(30) NOT NULL,
    buyer_phone_number VARCHAR(30) NOT NULL,
    sku VARCHAR(50) NOT NULL,
    upc VARCHAR(50) NOT NULL,
    product_name VARCHAR(150) NOT NULL,
    quantity_purchased INT NOT NULL,
    currency VARCHAR(10) NOT NULL,
    item_price DECIMAL(18,2) NOT NULL,
    ship_service_level VARCHAR(30) NOT NULL,
    ship_address_1 VARCHAR(100) NOT NULL,
    ship_address_2 VARCHAR(100) NULL,
    ship_address_3 VARCHAR(100) NULL,
    ship_city VARCHAR(50) NOT NULL,
    ship_state VARCHAR(50) NOT NULL,
    ship_postal_code VARCHAR(10) NOT NULL,
    ship_country VARCHAR(30) NOT NULL
);
GO
