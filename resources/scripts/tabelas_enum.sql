-- Criando Tabelas Enum

DROP TABLE IF EXISTS StatusDespacho;
CREATE TABLE StatusDespacho (
		[IDStatus] INT PRIMARY KEY,
		[NomeStatus] VARCHAR(50) NOT NULL
	);
	INSERT INTO StatusDespacho ([IDStatus], [NomeStatus])
	VALUES 
		(1, 'Em processamento'),
		(2, 'Pronto para Envio'),
		(3, 'Entregue'),
		(4, 'Cancelado');
		
	-- Tabela de estado de monitoramento do pedido - controle de loja

DROP TABLE IF EXISTS StatusPedido;
	CREATE TABLE StatusPedido (
		Status_ID INT PRIMARY KEY NOT NULL,
		Nome_Status VARCHAR(50) NOT NULL
	);

	INSERT INTO StatusPedido (Status_ID, Nome_Status) VALUES
	(1,'Pendente'),
	(2, 'Em processamento'),
	(3, 'Enviado'),
	(4, 'Entregue'),
	(5,'Cancelado');

-- Fim TAbelas Enum

ALTER TABLE RequisicoesCompra ADD CONSTRAINT FK_RC_STAT FOREIGN KEY (pr_status_pedido) REFERENCES StatusPedido (Status_ID) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE Checkout ADD CONSTRAINT FK_SD_D FOREIGN KEY (status_despacho) REFERENCES StatusDespacho(IDStatus) ON DELETE CASCADE ON UPDATE CASCADE;
