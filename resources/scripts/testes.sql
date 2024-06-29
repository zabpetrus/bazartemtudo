USE BazarDB;


USE [BazarDB]
GO
/*
INSERT INTO [dbo].[Checkout]
           ([Pedido_Id]
           ,[Pedido_ClienteId]
           ,[Total_Pedido]
           ,[Status_Despacho]
           ,[DataDespacho]
           ,[Data_Registro]
           ,[Data_Atualizacao]) */

SELECT 
    pe.Id AS PedidoId,
    pe.ClientesId,
    SUM(ipe.Item_Price * ipe.Quantity_Purchased) AS TotalPedido,
    1 AS AlgumaCoisa,
    pe.Purchase_Date,
    GETDATE() AS Data_Registro,
    GETDATE() AS Data_Atualizacao
FROM Pedidos pe
INNER JOIN ItensPedidos ipe ON ipe.PedidoId = pe.Id
GROUP BY pe.Id, pe.ClientesId, pe.Purchase_Date
ORDER BY TotalPedido DESC; -- Ordena pelo TotalPedido em ordem decrescente





