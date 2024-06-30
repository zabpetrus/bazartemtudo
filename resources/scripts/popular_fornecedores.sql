
-- Inserindo Fornecedores
USE BazarDB;


-- Inserção 1
INSERT INTO [dbo].[Fornecedores]
           ([Nome_Fornecedor] ,[CNPJ] ,[Endereco_ID] ,[Telefone] ,[Email],[Website] ,[Data_Registro],[Data_Atualizacao])     
	 SELECT 'Fornecedor A', '12.345.678/0001-01', 1, '(11) 1234-5678', 'fornecedor_a@example.com', 'www.fornecedora.com', GETDATE(), GETDATE()
	 WHERE NOT EXISTS ( SELECT 1 FROM [dbo].[Fornecedores] f  WHERE f.CNPJ = '12.345.678/0001-01' );

-- Inserção 2
INSERT INTO [dbo].[Fornecedores]
           ([Nome_Fornecedor] ,[CNPJ] ,[Endereco_ID] ,[Telefone] ,[Email],[Website] ,[Data_Registro],[Data_Atualizacao])   
     SELECT  'Fornecedor B', '98.765.432/0001-02', 2, '(21) 9876-5432', 'fornecedor_b@example.com', 'www.fornecedorb.com', GETDATE(), GETDATE()
	 WHERE NOT EXISTS ( SELECT 1  FROM [dbo].[Fornecedores] f  WHERE f.CNPJ = '98.765.432/0001-02' );

-- Inserção 3
INSERT INTO [dbo].[Fornecedores]
           ([Nome_Fornecedor] ,[CNPJ] ,[Endereco_ID] ,[Telefone] ,[Email],[Website] ,[Data_Registro],[Data_Atualizacao])   
     SELECT  'Fornecedor C', '11.222.333/0001-03', 3, '(31) 1122-3344', 'fornecedor_c@example.com', 'www.fornecedorc.com', GETDATE(), GETDATE()
	 WHERE NOT EXISTS ( SELECT 1  FROM [dbo].[Fornecedores] f  WHERE f.CNPJ = '11.222.333/0001-03' ); 

-- Inserção 4
INSERT INTO [dbo].[Fornecedores]
           ([Nome_Fornecedor] ,[CNPJ] ,[Endereco_ID] ,[Telefone] ,[Email],[Website] ,[Data_Registro],[Data_Atualizacao])   
     SELECT 'Fornecedor D', '44.555.666/0001-04', 4, '(41) 4455-6666', 'fornecedor_d@example.com', 'www.fornecedord.com', GETDATE(), GETDATE()
	  WHERE NOT EXISTS ( SELECT 1  FROM [dbo].[Fornecedores] f  WHERE f.CNPJ = '44.555.666/0001-04' ); 

-- Inserção 5
INSERT INTO [dbo].[Fornecedores]
           ([Nome_Fornecedor] ,[CNPJ] ,[Endereco_ID] ,[Telefone] ,[Email],[Website] ,[Data_Registro],[Data_Atualizacao])   
     SELECT 'Fornecedor E', '77.888.999/0001-05', 5, '(51) 7788-9999', 'fornecedor_e@example.com', 'www.fornecedore.com', GETDATE(), GETDATE()
	 WHERE NOT EXISTS ( SELECT 1  FROM [dbo].[Fornecedores] f  WHERE f.CNPJ = '77.888.999/0001-05' ); 
