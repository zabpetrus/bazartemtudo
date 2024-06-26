USE [BazarDB];
GO

IF OBJECT_ID('Procedure_Entrantes', 'P') IS NOT NULL
   DROP PROCEDURE Procedure_Entrantes;
GO

CREATE PROCEDURE Procedure_Entrantes
AS
BEGIN
	-- Em requisicao compra vemos os produtos que chegaram

	DECLARE @id INT;
	DECLARE @qte INT;

	SELECT @id = rc.pr_produto_id, @qte = rc.pr_quantidade FROM RequisicoesCompra rc WHERE rc.pr_status_pedido = 2;

	UPDATE Estoque SET is_actual_qte = @qte WHERE Produto_id = @id;

	PRINT 'Atualizacao do Produto de ID ' + CONVERT(VARCHAR, @id )  + ' no Estoque, inseridas ' + CONVERT(VARCHAR, @qte )  + ' unidades';

END
