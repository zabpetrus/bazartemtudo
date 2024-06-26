USE [BazarDB];
GO

IF OBJECT_ID('Procedure_Atualizar_Estoque', 'P') IS NOT NULL
   DROP PROCEDURE DP2;
GO

CREATE PROCEDURE Procedure_Atualizar_Estoque
AS
BEGIN 
        -- Transaction begins

        -- Declarando variáveis
        DECLARE @Item_ID INT;
        DECLARE @Produto_ID INT;
        DECLARE @CursorItens CURSOR;
        DECLARE @qtetemp INT;
        DECLARE @currentqte INT;

     
        -- Cursor to get ItensPedidos_ID to be updated
        SET @CursorItens = CURSOR FOR

        SELECT 
		ItensPedidos.ip_ID, 
		ItensPedidos.ip_produto_id 
		FROM ItensPedidos INNER JOIN Estoque
		ON Estoque.Produto_id = ItensPedidos.ip_produto_id
		WHERE Estoque.is_actual_qte > 0;


        -- Open cursor to fetch
        OPEN @CursorItens;

        -- getting the product id and item id
        FETCH NEXT FROM @CursorItens INTO @Item_ID,  @Produto_ID;

        -- while update, other works are running
        WHILE @@FETCH_STATUS = 0
        BEGIN
            -- Update ItensPedidos - disponibilidade, atribuindo
            UPDATE ItensPedidos 
            SET ip_item_status = 1 
            WHERE ItensPedidos.ip_produto_id = @Produto_ID;

			PRINT 'Atualização em itensPedidos. Produto id ' + CONVERT(VARCHAR, @Produto_ID )  + ' liberado ';

            -- get quantidade
            SELECT @qtetemp = ip_quantity_purchased FROM ItensPedidos Ipe
            WHERE Ipe.ip_produto_id = @Produto_ID AND Ipe.ip_pedido_item_id = @Item_ID;

            -- get current storage number of itenspedidos
            SELECT @currentqte = es.is_actual_qte FROM Estoque es WHERE es.Produto_id = @Produto_ID;

            -- updating storage... again
            UPDATE Estoque 
            SET is_actual_qte = (@currentqte - @qtetemp)  
            WHERE Produto_id =  @Produto_ID;
            PRINT 'Estoque atualizado = ' + CAST((@currentqte - @qtetemp) AS VARCHAR);
			

            FETCH NEXT FROM @CursorItens INTO @Item_ID, @Produto_ID;
        END

        CLOSE @CursorItens;
        DEALLOCATE @CursorItens;

    END 

