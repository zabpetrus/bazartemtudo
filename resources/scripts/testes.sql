USE BazarDB;


SELECT 
Pe.pedido_ID, 
Ck.total_pedido,
GETDATE() AS CurrentTime
FROM Pedidos Pe 
INNER JOIN Checkout Ck ON Ck.Pedido_id = Pe.pedido_ID ;
