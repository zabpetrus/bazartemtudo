USE BazarDB;


-- Percorrendo os itenspedidos e vendo quais estão prontos
IF OBJECT_ID('Procedure_Checkout', 'P') IS NOT NULL
   DROP PROCEDURE Procedure_Checkout;
GO

CREATE PROCEDURE Procedure_Checkout
AS
BEGIN

	  DECLARE @pedidoID INT;
	  DECLARE @PedidoPronto CURSOR;

	  SET @PedidoPronto = CURSOR FOR

	  SELECT ipe.ip_pedido_id 
	  FROM ItensPedidos ipe
	  GROUP BY ip_pedido_id
	  HAVING SUM(CASE WHEN ipe.ip_item_status = 0 THEN 1 ELSE 0 END) = 0;

	  OPEN @PedidoPronto;

	  FETCH NEXT FROM @PedidoPronto INTO @pedidoID;

	  WHILE @@FETCH_STATUS = 0
      BEGIN

		  UPDATE Pedidos  SET pedido_ship_state = 2 WHERE Pedidos.pedido_id = @pedidoID;

		  PRINT 'Pedidos id ' + CONVERT(VARCHAR, @pedidoID )  + 'atualizado ';

		  UPDATE DespachoMercadorias SET Status_Entrega = 2 WHERE DespachoMercadorias.Pedido_ID = @pedidoID;
	 
		  PRINT 'Despacho do pedido ' + CONVERT(VARCHAR, @pedidoID ) ;

		  UPDATE Checkout SET status_despacho = 2, data_despacho = GETDATE() WHERE Checkout.Pedido_id = @pedidoID;

		  PRINT 'Checkout atualizado para o do pedido ' + CONVERT(VARCHAR, @pedidoID ) ;

		  FETCH NEXT FROM @PedidoPronto INTO @pedidoID;

	  END

	   CLOSE @PedidoPronto;
       DEALLOCATE @PedidoPronto;

END