USE [BazarDB];
GO
-- Começando excluindo as constraints caso elas existam
-- Procedimento para correção do banco


-- Remoção da constraint FK_RC_FORN em RequisicoesCompra
IF EXISTS (
    SELECT 1
    FROM information_schema.table_constraints
    WHERE table_name = 'RequisicoesCompra' 
    AND constraint_name = 'FK_RC_FORN'
)
BEGIN
    ALTER TABLE RequisicoesCompra
    DROP CONSTRAINT FK_RC_FORN;
END;

-- Remoção da constraint FK_RC_PROD em RequisicoesCompra
IF EXISTS (
    SELECT 1
    FROM information_schema.table_constraints
    WHERE table_name = 'RequisicoesCompra' 
    AND constraint_name = 'FK_RC_PROD'
)
BEGIN
    ALTER TABLE RequisicoesCompra
    DROP CONSTRAINT FK_RC_PROD;
END;

-- Remoção da Constrante FK_RC_STAT em RequisicoesCompra
IF EXISTS (
    SELECT 1
    FROM information_schema.table_constraints
    WHERE table_name = 'RequisicoesCompra'
    AND constraint_name = 'FK_RC_STAT'
)
BEGIN
    ALTER TABLE RequisicoesCompra
    DROP CONSTRAINT FK_RC_STAT;
END;

-- Remoção da constraint FK_PED_CLI em Pedidos
IF EXISTS (
    SELECT 1
    FROM information_schema.table_constraints
    WHERE table_name = 'Pedidos' 
    AND constraint_name = 'FK_PED_CLI'
)
BEGIN
    ALTER TABLE Pedidos
    DROP CONSTRAINT FK_PED_CLI;
END;

-- Remoção da constraint FK_IP_PE em ItensPedidos
IF EXISTS (
    SELECT 1
    FROM information_schema.table_constraints
    WHERE table_name = 'ItensPedidos' 
    AND constraint_name = 'FK_IP_PE'
)
BEGIN
    ALTER TABLE ItensPedidos
    DROP CONSTRAINT FK_IP_PE;
END;

-- Remoção da constraint FK_IP_PROD em ItensPedidos
IF EXISTS (
    SELECT 1
    FROM information_schema.table_constraints
    WHERE table_name = 'ItensPedidos' 
    AND constraint_name = 'FK_IP_PROD'
)
BEGIN
    ALTER TABLE ItensPedidos
    DROP CONSTRAINT FK_IP_PROD;
END;

-- Remoção da constraint FK_NF_PE em NotasFiscais
IF EXISTS (
    SELECT 1
    FROM information_schema.table_constraints
    WHERE table_name = 'NotasFiscais' 
    AND constraint_name = 'FK_NF_PE'
)
BEGIN
    ALTER TABLE NotasFiscais
    DROP CONSTRAINT FK_NF_PE;
END;

-- Remoção da constraint FK_SD_D em Checkout
IF EXISTS (
    SELECT 1
    FROM information_schema.table_constraints
    WHERE table_name = 'Checkout' 
    AND constraint_name = 'FK_SD_D'
)
BEGIN
    ALTER TABLE Checkout
    DROP CONSTRAINT FK_SD_D;
END;

-- Remoção da constraint FK_DM_PED em DespachoMercadorias
IF EXISTS (
    SELECT 1
    FROM information_schema.table_constraints
    WHERE table_name = 'DespachoMercadorias' 
    AND constraint_name = 'FK_DM_PED'
)
BEGIN
    ALTER TABLE DespachoMercadorias
    DROP CONSTRAINT FK_DM_PED;
END;

-- Remoção da constraint FK_DM_TRANS em DespachoMercadorias
IF EXISTS (
    SELECT 1
    FROM information_schema.table_constraints
    WHERE table_name = 'DespachoMercadorias' 
    AND constraint_name = 'FK_DM_TRANS'
)
BEGIN
    ALTER TABLE DespachoMercadorias
    DROP CONSTRAINT FK_DM_TRANS;
END;

-- Remoção da constraint FK_EST_PROD em Estoque
IF EXISTS (
    SELECT 1
    FROM information_schema.table_constraints
    WHERE table_name = 'Estoque' 
    AND constraint_name = 'FK_EST_PROD'
)
BEGIN
    ALTER TABLE Estoque
    DROP CONSTRAINT FK_EST_PROD;
END;

IF EXISTS (
    SELECT 1
    FROM information_schema.table_constraints
    WHERE table_name = 'Checkout' 
    AND constraint_name = 'FK_P_C'
)
BEGIN
    ALTER TABLE Checkout
    DROP CONSTRAINT FK_P_C;
END;





DROP TABLE IF EXISTS [Clientes];

CREATE TABLE [dbo].[Clientes](
	[cliente_id] [INT] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[cliente_name] [varchar](80) NOT NULL,
	[cliente_email] [varchar](50) NOT NULL,
	[cliente_cpf] [varchar](30) NOT NULL,
	[cliente_phone_number] [varchar](30) NOT NULL	
);


DROP TABLE IF EXISTS [Produtos];

CREATE TABLE [dbo].[Produtos](
	[produto_id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[produto_name] VARCHAR(150) NOT NULL,
	[produto_sku] VARCHAR(50) NOT NULL,
    [produto_upc] VARCHAR(50) NOT NULL,
	[produto_item_price] DECIMAL(18,2) NOT NULL,   
);


DROP TABLE IF EXISTS [Pedidos];

CREATE TABLE [dbo].[Pedidos](
	[pedido_ID] INT PRIMARY KEY IDENTITY(1,1) NOT NULL, --id exclusivo (controle interno) do pedido
	[pedido_cliente_id] INT NOT NULL, -- id do cliente (controle interno)
	[pedido_def_id] INT NOT NULL, --id do cliente (vem do marketplace - controle externo)
    [pedido_purchase_date] DATETIME2 NOT NULL, -- data da compra
    [pedido_payments_date] DATETIME2 NOT NULL, -- data do pagamento
	[pedido_ship_city] VARCHAR(50) NOT NULL, -- cidade de despacho do pedido
    [pedido_ship_state] VARCHAR(50) NOT NULL,-- estado de despacho do pedido
    [pedido_ship_postal_code] VARCHAR(10) NOT NULL, -- codigo postal de despacho do pedido
	[pedido_ship_address_1] varchar(100) NULL,
	[pedido_ship_address_2] varchar(100) NULL,
	[pedido_ship_address_3] varchar(100) NULL,
    [pedido_ship_country] VARCHAR(30) NOT NULL,	-- pais de despacho do pedido
	[pedido_currency] VARCHAR(10) NOT NULL, -- moeda corrente do pedido
	[pedido_ship_service_level] VARCHAR(20) DEFAULT 'Standard Shipping' CHECK ([Pedido_ship_service_level] IN ('Standard Shipping', 'Express Shipping', 'Priority Shipping')),
	[pedido_status_delivery] VARCHAR(20) NOT NULL DEFAULT 'Processing' CHECK ([Pedido_status_delivery] IN ('Processing', 'Shipped', 'Delivered', 'In Transit', 'Returned'))
);

DROP TABLE IF EXISTS [Enderecos];

CREATE TABLE [dbo].[Enderecos](
	[end_ID] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[end_pedido_id] INT NOT NULL,
	[end_logradouro_1] VARCHAR(50) NOT NULL,
	[end_logradouro_2] VARCHAR(50) NULL,
	[end_logradouro_3] VARCHAR(50) NULL,
	[end_cep] VARCHAR(10) NOT NULL,
	[end_numero] INT NOT NULL,
	[end_cidade] VARCHAR(50) NOT NULL,
	[end_estado] VARCHAR(50) NOT NULL,
	[end_pais] VARCHAR(50) NOT NULL
);

DROP TABLE IF EXISTS [ItensPedidos];

CREATE TABLE [dbo].[ItensPedidos] (
	[ip_ID] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[ip_pedido_id] INT NOT NULL, -- PedidoID vindo de Pedidos
	[ip_produto_id] INT NOT NULL, -- ProdutoID vindo de Produtos
	[ip_pedido_item_id] INT NOT NULL, -- Ordem ID da Fonte
	[ip_produto_price] DECIMAL(18,2) NOT NULL, -- preco
	[ip_quantity_purchased] INT NOT NULL, -- quantidade 
	[ip_item_status] VARCHAR(20) NOT NULL DEFAULT 'Processing' CHECK ([ip_item_status] IN ('Processing', 'Shipped', 'Delivered', 'In Transit', 'Returned')) -- Se está disponivel
);





-- TABELA DE REQUISICAO DE COMPRA

DROP TABLE IF EXISTS [RequisicoesCompra];

CREATE TABLE [dbo].[RequisicoesCompra](
	[pr_id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[pr_produto_id] INT NOT NULL,-- id do produto registrado
	[pr_fornecedor_id] INT NOT NULL, -- id do fornecedor. Neste caso,será um forncedor generalista tipo atacadão
	[pr_quantidade] INT NOT NULL, -- quantidade do produto
	[pr_preco_unitario] DECIMAL(18,2) NOT NULL, -- preco individual do produto
	[pr_preco_total] DECIMAL (18,2) NOT NULL, -- o custo total da compra
	[pr_data_requisicao] DATETIME2 NOT NULL, -- data da requisicao
	[pr_status_pedido] INT DEFAULT 1 --termo em ingles que indica que um produto está "aguardando chegada" 
);

-- TABELA ESTOQUE
DROP TABLE IF EXISTS [Estoque];

CREATE TABLE [dbo].[Estoque] (
	[is_id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL, -- id de controle interno do estoque
	[Produto_id] INT NOT NULL, -- id do produto
	[is_actual_qte] INT DEFAULT 0 NOT NULL, -- o que é comprado
	[is_minimal_qte] INT DEFAULT 0 NOT NULL,--vem dos pedidos: relação à carga. É atualizado quando vem a carga
);

-- TABELA FORNECEDORES

DROP TABLE IF EXISTS [Fornecedores];

CREATE TABLE [dbo].[Fornecedores] (
	[forn_id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL, -- id do fornecedor
	[forn_name] VARCHAR(50) NOT NULL, -- Nome Fantasia do Fornecedor
	[forn_cnpj] VARCHAR(30) NOT NULL UNIQUE, -- Cnpj do Fornecedor
	[forn_email] VARCHAR(50) NOT NULL, -- Email de contato do Fornecedor. A ordem de serviço será enviada para o email designado
	[forn_cidade] VARCHAR(50) NOT NULL, -- Cidade do Fornecedor
	[forn_pais] VARCHAR(30) NOT NULL -- País do Fornecedor
);



DROP TABLE IF EXISTS [Checkout];

	CREATE TABLE [dbo].[Checkout](
		[Checkout_ID] INT PRIMARY KEY IDENTITY NOT NULL,
		[Pedido_id] INT NOT NULL,
		[total_pedido] DECIMAL(10,2) NOT NULL,
		[status_despacho] INT NOT NULL,
		[data_despacho] DATETIME NOT NULL,
	);


DROP TABLE IF EXISTS [NotasFiscais];

	CREATE TABLE [dbo].[NotasFiscais](
		[NotaFiscal_id] INT PRIMARY KEY IDENTITY NOT NULL,
		[Pedido_ID] INT  NOT NULL,
		[Valor_Total] DECIMAL(10,2) NOT NULL,
		[Data_Emissao] DATETIME NOT NULL
	);

DROP TABLE IF EXISTS [Transportadoras];
	CREATE TABLE [dbo].[Transportadoras](
		[Transportadora_id] INT PRIMARY KEY IDENTITY NOT NULL,
		[Nome_Transportadora] VARCHAR(150) NOT NULL,
		[CNPJ_Transportadora] VARCHAR(50) NOT NULL,
		[Tipo_Servico] VARCHAR(50) NOT NULL,
		[Custo_Frete] DECIMAL(18,0) NOT NULL
	);


DROP TABLE IF EXISTS [DespachoMercadorias];
	CREATE TABLE [dbo].[DespachoMercadorias](
		[Despacho_id] INT PRIMARY KEY IDENTITY NOT NULL,
		[Pedido_ID] INT NOT NULL,
		[Transportadora_ID] INT  NOT NULL,
		[Status_Entrega] INT NOT NULL DEFAULT 1,
		[Data_Liberacao] DATETIME NOT NULL
	);


ALTER TABLE RequisicoesCompra ADD CONSTRAINT FK_RC_FORN FOREIGN KEY (pr_fornecedor_id) REFERENCES Fornecedores(forn_id) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE RequisicoesCompra ADD CONSTRAINT FK_RC_PROD FOREIGN KEY (pr_produto_id) REFERENCES Produtos(Produto_id) ON DELETE CASCADE ON UPDATE CASCADE;


ALTER TABLE Pedidos ADD CONSTRAINT FK_PED_CLI FOREIGN KEY (pedido_cliente_id) REFERENCES Clientes (cliente_id) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE ItensPedidos ADD CONSTRAINT FK_IP_PE FOREIGN KEY (ip_pedido_id) REFERENCES Pedidos (Pedido_ID) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE ItensPedidos ADD CONSTRAINT FK_IP_PROD FOREIGN KEY (ip_produto_id) REFERENCES Produtos (Produto_id) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE NotasFiscais ADD CONSTRAINT FK_NF_PE FOREIGN KEY (Pedido_ID) REFERENCES Pedidos (Pedido_ID) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE Checkout ADD CONSTRAINT FK_P_C FOREIGN KEY (Pedido_id) REFERENCES Pedidos (Pedido_ID) ON DELETE CASCADE ON UPDATE CASCADE;


ALTER TABLE DespachoMercadorias ADD CONSTRAINT FK_DM_PED FOREIGN KEY (Pedido_ID) REFERENCES Pedidos (Pedido_ID) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE DespachoMercadorias ADD CONSTRAINT FK_DM_TRANS FOREIGN KEY (Transportadora_ID) REFERENCES Transportadoras (Transportadora_id) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE Estoque ADD CONSTRAINT FK_EST_PROD FOREIGN KEY (Produto_id) REFERENCES Produtos(Produto_id)ON DELETE CASCADE ON UPDATE CASCADE;

GO

