

INSERT INTO Perfis (Nome, Descricao, Data_Registro, Data_Atualizacao) 
SELECT 'Admin', 'Administrador do sistema', GETDATE(), GETDATE()  
WHERE NOT EXISTS (SELECT 1 FROM Perfis WHERE Nome='Admin');

INSERT INTO Perfis (Nome, Descricao, Data_Registro, Data_Atualizacao) 
SELECT 'User', 'Usuário comum do sistema', GETDATE(), GETDATE() 
WHERE NOT EXISTS (SELECT 1 FROM Perfis WHERE Nome='User');

INSERT INTO Perfis (Nome, Descricao, Data_Registro, Data_Atualizacao) 
SELECT 'Manager', 'Gerente do sistema', GETDATE(), GETDATE()  
WHERE NOT EXISTS (SELECT 1 FROM Perfis WHERE Nome='Manager');

INSERT INTO Perfis (Nome, Descricao, Data_Registro, Data_Atualizacao) 
SELECT 'Support', 'Suporte técnico do sistema', GETDATE(), GETDATE()  
WHERE NOT EXISTS (SELECT 1 FROM Perfis WHERE Nome='Support');

INSERT INTO Perfis (Nome, Descricao, Data_Registro, Data_Atualizacao) 
SELECT 'Guest', 'Visitante do sistema', GETDATE(), GETDATE() 
WHERE NOT EXISTS (SELECT 1 FROM Perfis WHERE Nome='Guest'); 

