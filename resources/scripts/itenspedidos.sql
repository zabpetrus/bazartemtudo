USE BAZARDB;
INSERT INTO [dbo].[ItensPedidos]
           ([Order_Item_id]
           ,[Item_Price]
           ,[Quantity_Purchased]
           ,[Disponivel]
           ,[PedidoId]
           ,[ProdutoId]
           ,[Data_Registro]
           ,[Data_Atualizacao])
SELECT
    ca.order_item_id,         -- Order_Item_id da tabela Carga
    ca.item_price,            -- Item_Price da tabela Carga
    ca.quantity_purchased,
    0 AS Disponivel,          -- N�o est� dispon�vel (0) na tabela ItensPedidos
    pe.Id,                    -- PedidoId da tabela Pedidos
    pr.Id,                    -- ProdutoId da tabela Produtos
    GETDATE() AS Data_Registro,   -- Data de Registro atual
    GETDATE() AS Data_Atualizacao -- Data de Atualiza��o atual
FROM
	Carga ca
    
    LEFT JOIN Pedidos pe ON ca.order_id = pe.Order_id
    LEFT JOIN Produtos pr ON ca.upc = pr.upc AND ca.sku = pr.sku
WHERE
    NOT EXISTS (
        SELECT 1 
        FROM ItensPedidos ip
        WHERE ip.PedidoId = pe.Id 
        AND ip.ProdutoId = pr.Id
        AND ip.Order_Item_id = ca.order_item_id
    );

/*
INSERT INTO [dbo].[ItensPedidos]
           (
		    [PedidoId],
			[ProdutoId],
			[Order_Item_id]
           ,[Item_Price]
           ,[Quantity_Purchased]        
           ,[Data_Registro]
           ,[Data_Atualizacao]         
		   )*/
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
WHERE NOT EXISTS (
    SELECT 1 
    FROM ItensPedidos d
    WHERE d.PedidoId = pe.Id 
    AND d.ProdutoId = pr.Id
    AND d.order_item_id = ca.order_item_id
);
	
