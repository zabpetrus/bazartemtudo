
-- Inserção 1
INSERT INTO [dbo].[Transportadoras] ([NomeTransportadora],[CNPJ]  ,[TipoServico] ,[CustoFrete] ,[Data_Registro] ,[Data_Atualizacao])
     SELECT 'Transportadora A', '11.222.333/0001-01', 1, 50.00, GETDATE(), GETDATE() 
	 WHERE NOT EXISTS (SELECT 1 FROM [dbo].[Transportadoras] f WHERE f.CNPJ = '11.222.333/0001-01');

-- Inserção 2
INSERT INTO [dbo].[Transportadoras] ([NomeTransportadora],[CNPJ]  ,[TipoServico] ,[CustoFrete] ,[Data_Registro] ,[Data_Atualizacao])
     SELECT 'Transportadora B', '22.333.444/0001-02', 2, 75.00, GETDATE(), GETDATE()
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[Transportadoras] f WHERE f.CNPJ = '22.333.444/0001-02');

-- Inserção 3
INSERT INTO [dbo].[Transportadoras] ([NomeTransportadora],[CNPJ]  ,[TipoServico] ,[CustoFrete] ,[Data_Registro] ,[Data_Atualizacao])
   SELECT 'Transportadora C', '33.444.555/0001-03', 1, 60.00, GETDATE(), GETDATE()
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[Transportadoras] f WHERE f.CNPJ = '33.444.555/0001-03');

-- Inserção 4
INSERT INTO [dbo].[Transportadoras] ([NomeTransportadora],[CNPJ]  ,[TipoServico] ,[CustoFrete] ,[Data_Registro] ,[Data_Atualizacao])
SELECT 'Transportadora D', '44.555.666/0001-04', 3, 90.00, GETDATE(), GETDATE()
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[Transportadoras] f WHERE f.CNPJ = '44.555.666/0001-04');

-- Inserção 5
INSERT INTO [dbo].[Transportadoras] ([NomeTransportadora],[CNPJ]  ,[TipoServico] ,[CustoFrete] ,[Data_Registro] ,[Data_Atualizacao])
SELECT 'Transportadora E', '55.666.777/0001-05', 2, 80.00, GETDATE(), GETDATE()
WHERE NOT EXISTS (SELECT 1 FROM [dbo].[Transportadoras] f WHERE f.CNPJ = '55.666.777/0001-05');
