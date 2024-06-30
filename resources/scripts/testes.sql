
INSERT INTO [dbo].[DespachoMercadorias]
           ([Status_Entrega]
           ,[Data_Liberacao]
           ,[Pedido_Id]
           ,[Transportadora_ID]
           ,[Data_Registro]
           ,[Data_Atualizacao])
 SELECT 
'Pendente',
GETDATE(),
pe.Id,
tr.Id,
pe.Data_Atualizacao,
pe.Data_Registro
FROM Pedidos pe
INNER JOIN Transportadoras tr ON tr.Id = 1
WHERE NOT EXISTS(;

