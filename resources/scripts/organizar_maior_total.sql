SELECT 
pe.Id AS PedidoID,
SUM (tp.Item_Price * tp.Quantity_Purchased ) AS SOMA,
pe.Purchase_Date AS Prioridade
FROM ItensPedidos tp
INNER JOIN Pedidos pe ON tp.PedidoId = pe.Id
GROUP BY pe.Id,pe.Purchase_Date 
ORDER BY SOMA DESC, Prioridade
DESC;


SELECT 
SUM (tp.Item_Price * tp.Quantity_Purchased ) AS Total_Pedido,
'Em_Processamento' AS Status_Despacho,
GETDATE() AS DataDespacho,
pe.Id AS PedidoID
FROM ItensPedidos tp
INNER JOIN Pedidos pe ON tp.PedidoId = pe.Id
GROUP BY pe.Id,pe.Purchase_Date 
ORDER BY Total_Pedido DESC, pe.Purchase_Date
DESC



SELECT ipx.PedidoId, ipx.ProdutoId, ipx.Disponivel FROM ItensPedidos ipx 
GROUP BY ipx.PedidoId, ipx.ProdutoId, ipx.Disponivel;



WITH PedidoTotais AS (
    SELECT 
        pe.Id AS PedidoID,
        SUM(tp.Item_Price * tp.Quantity_Purchased) AS SOMA,
        pe.Purchase_Date AS Prioridade
    FROM 
        ItensPedidos tp
    INNER JOIN 
        Pedidos pe ON tp.PedidoId = pe.Id
    GROUP BY 
        pe.Id, pe.Purchase_Date
)
SELECT 
    pt.PedidoID,
    ipx.ProdutoId,
    ipx.Disponivel,
    pt.SOMA,
    pt.Prioridade
FROM 
    PedidoTotais pt
INNER JOIN 
    ItensPedidos ipx ON pt.PedidoID = ipx.PedidoId
ORDER BY 
    pt.SOMA DESC, pt.Prioridade DESC, ipx.ProdutoId;

