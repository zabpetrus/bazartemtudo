USE BazarDB;

MERGE INTO ItensPedidos AS target
USING (
    SELECT DISTINCT
        pe.Id AS Pedido_ID,
        pr.Id AS Produto_ID,
        ca.order_item_id,
        ca.item_price,
        ca.quantity_purchased,
        GETDATE() AS DataCriacao,
        GETDATE() AS DataAtualizacao
    FROM Pedidos pe
    LEFT JOIN Carga ca ON ca.order_id = pe.Order_id
    LEFT JOIN Produtos pr ON ca.upc = pr.upc AND ca.sku = pr.sku
) AS source
ON target.PedidoID = source.Pedido_ID
   AND target.ProdutoID = source.Produto_ID
   AND target.order_item_id = source.order_item_id
WHEN NOT MATCHED BY TARGET THEN
    INSERT (PedidoID, ProdutoID, order_item_id, item_price, quantity_purchased, [Data_Registro], [Data_Atualizacao])
    VALUES (source.Pedido_ID, source.Produto_ID, source.order_item_id, source.item_price, source.quantity_purchased, source.DataCriacao, source.DataAtualizacao);
