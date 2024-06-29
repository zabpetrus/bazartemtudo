using BazarTemTudo.InfraData.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BazarTemTudo.InfraData.Procedures
{
    public static class CargaProcedures
    {
        private static ApplicationDBContext _dbContext;

        public static void SetDbContext(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        private static bool PopularCheckout() 
        {
            try
            {
                var sql = @"                
               INSERT INTO [dbo].[Produtos]
               (product_name, SKU, UPC, Valor, Data_Registro, Data_Atualizacao)
			    SELECT DISTINCT Ca.product_name, ca.sku, ca.upc,ca.item_price,GETDATE(), GETDATE() FROM Carga Ca
			    LEFT JOIN Produtos ON Produtos.UPC = Ca.upc WHERE NOT EXISTS 
			    (SELECT 1 FROM Produtos WHERE Produtos.UPC = Ca.upc );
                ";

                var resp = _dbContext.Database.ExecuteSqlRaw(sql);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a operação em Clientes: " + ex.Message);
            }
        }

        private static bool PopulateDespachoMercadorias() 
        {
            try
            {
                var sql = @"                
               INSERT INTO [dbo].[Produtos]
               (product_name, SKU, UPC, Valor, Data_Registro, Data_Atualizacao)
			    SELECT DISTINCT Ca.product_name, ca.sku, ca.upc,ca.item_price,GETDATE(), GETDATE() FROM Carga Ca
			    LEFT JOIN Produtos ON Produtos.UPC = Ca.upc WHERE NOT EXISTS 
			    (SELECT 1 FROM Produtos WHERE Produtos.UPC = Ca.upc );
                ";

                var resp = _dbContext.Database.ExecuteSqlRaw(sql);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a operação em Clientes: " + ex.Message);
            }
        }

        private static bool PopulateEnderecos() 
        {
            try
            {
                var sql = @"                
               INSERT INTO [dbo].[Produtos]
               (product_name, SKU, UPC, Valor, Data_Registro, Data_Atualizacao)
			    SELECT DISTINCT Ca.product_name, ca.sku, ca.upc,ca.item_price,GETDATE(), GETDATE() FROM Carga Ca
			    LEFT JOIN Produtos ON Produtos.UPC = Ca.upc WHERE NOT EXISTS 
			    (SELECT 1 FROM Produtos WHERE Produtos.UPC = Ca.upc );
                ";

                var resp = _dbContext.Database.ExecuteSqlRaw(sql);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a operação em Clientes: " + ex.Message);
            }
        }

        private static bool PopulateEstoque() 
        {
            try
            {
                var sql = @"                
               INSERT INTO [dbo].[Produtos]
               (product_name, SKU, UPC, Valor, Data_Registro, Data_Atualizacao)
			    SELECT DISTINCT Ca.product_name, ca.sku, ca.upc,ca.item_price,GETDATE(), GETDATE() FROM Carga Ca
			    LEFT JOIN Produtos ON Produtos.UPC = Ca.upc WHERE NOT EXISTS 
			    (SELECT 1 FROM Produtos WHERE Produtos.UPC = Ca.upc );
                ";

                var resp = _dbContext.Database.ExecuteSqlRaw(sql);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a operação em Clientes: " + ex.Message);
            }
        }

        private static bool PopulateFornecedores() 
        {
            try
            {
                var sql = @"                
               INSERT INTO [dbo].[Produtos]
               (product_name, SKU, UPC, Valor, Data_Registro, Data_Atualizacao)
			    SELECT DISTINCT Ca.product_name, ca.sku, ca.upc,ca.item_price,GETDATE(), GETDATE() FROM Carga Ca
			    LEFT JOIN Produtos ON Produtos.UPC = Ca.upc WHERE NOT EXISTS 
			    (SELECT 1 FROM Produtos WHERE Produtos.UPC = Ca.upc );
                ";

                var resp = _dbContext.Database.ExecuteSqlRaw(sql);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a operação em Clientes: " + ex.Message);
            }
        }

        private static bool PopulateItensPedidos() 
        {
            try
            {
                var sql = @"                
               INSERT INTO [dbo].[Produtos]
               (product_name, SKU, UPC, Valor, Data_Registro, Data_Atualizacao)
			    SELECT DISTINCT Ca.product_name, ca.sku, ca.upc,ca.item_price,GETDATE(), GETDATE() FROM Carga Ca
			    LEFT JOIN Produtos ON Produtos.UPC = Ca.upc WHERE NOT EXISTS 
			    (SELECT 1 FROM Produtos WHERE Produtos.UPC = Ca.upc );
                ";

                var resp = _dbContext.Database.ExecuteSqlRaw(sql);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a operação em Clientes: " + ex.Message);
            }
        }

        private static bool PopulateNotaFiscal() 
        {
            try
            {
                var sql = @"                
               INSERT INTO [dbo].[Produtos]
               (product_name, SKU, UPC, Valor, Data_Registro, Data_Atualizacao)
			    SELECT DISTINCT Ca.product_name, ca.sku, ca.upc,ca.item_price,GETDATE(), GETDATE() FROM Carga Ca
			    LEFT JOIN Produtos ON Produtos.UPC = Ca.upc WHERE NOT EXISTS 
			    (SELECT 1 FROM Produtos WHERE Produtos.UPC = Ca.upc );
                ";

                var resp = _dbContext.Database.ExecuteSqlRaw(sql);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a operação em Clientes: " + ex.Message);
            }

        }

        private static bool PopulatePedidos() 
        {
            try
            {
                var sql = @"                
               INSERT INTO [dbo].[Produtos]
               (product_name, SKU, UPC, Valor, Data_Registro, Data_Atualizacao)
			    SELECT DISTINCT Ca.product_name, ca.sku, ca.upc,ca.item_price,GETDATE(), GETDATE() FROM Carga Ca
			    LEFT JOIN Produtos ON Produtos.UPC = Ca.upc WHERE NOT EXISTS 
			    (SELECT 1 FROM Produtos WHERE Produtos.UPC = Ca.upc );
                ";

                var resp = _dbContext.Database.ExecuteSqlRaw(sql);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a operação em Clientes: " + ex.Message);
            }

        }

        private static bool PopulatePerfil()
        {
            try
            {
                var sql = @"                
               INSERT INTO [dbo].[Produtos]
               (product_name, SKU, UPC, Valor, Data_Registro, Data_Atualizacao)
			    SELECT DISTINCT Ca.product_name, ca.sku, ca.upc,ca.item_price,GETDATE(), GETDATE() FROM Carga Ca
			    LEFT JOIN Produtos ON Produtos.UPC = Ca.upc WHERE NOT EXISTS 
			    (SELECT 1 FROM Produtos WHERE Produtos.UPC = Ca.upc );
                ";

                var resp = _dbContext.Database.ExecuteSqlRaw(sql);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a operação em Clientes: " + ex.Message);
            }

        }

        private static bool PopulateRequisicaoCompra()
        {
            try
            {
                var sql = @"                
               INSERT INTO [dbo].[Produtos]
               (product_name, SKU, UPC, Valor, Data_Registro, Data_Atualizacao)
			    SELECT DISTINCT Ca.product_name, ca.sku, ca.upc,ca.item_price,GETDATE(), GETDATE() FROM Carga Ca
			    LEFT JOIN Produtos ON Produtos.UPC = Ca.upc WHERE NOT EXISTS 
			    (SELECT 1 FROM Produtos WHERE Produtos.UPC = Ca.upc );
                ";

                var resp = _dbContext.Database.ExecuteSqlRaw(sql);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a operação em Clientes: " + ex.Message);
            }

        }

        private static bool PopulateTransportadoras() 
        {
            try
            {
                var sql = @"                
               INSERT INTO [dbo].[Produtos]
               (product_name, SKU, UPC, Valor, Data_Registro, Data_Atualizacao)
			    SELECT DISTINCT Ca.product_name, ca.sku, ca.upc,ca.item_price,GETDATE(), GETDATE() FROM Carga Ca
			    LEFT JOIN Produtos ON Produtos.UPC = Ca.upc WHERE NOT EXISTS 
			    (SELECT 1 FROM Produtos WHERE Produtos.UPC = Ca.upc );
                ";

                var resp = _dbContext.Database.ExecuteSqlRaw(sql);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a operação em Clientes: " + ex.Message);
            }

        }

        private static bool PopularProdutos()
        {
            try
            {
                var sql = @"                
               INSERT INTO [dbo].[Produtos]
               (product_name, SKU, UPC, Valor, Data_Registro, Data_Atualizacao)
			    SELECT DISTINCT Ca.product_name, ca.sku, ca.upc,ca.item_price,GETDATE(), GETDATE() FROM Carga Ca
			    LEFT JOIN Produtos ON Produtos.UPC = Ca.upc WHERE NOT EXISTS 
			    (SELECT 1 FROM Produtos WHERE Produtos.UPC = Ca.upc );
                ";

                var resp = _dbContext.Database.ExecuteSqlRaw(sql);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a operação em Clientes: " + ex.Message);
            }
        }

        private static bool PopularClientes()
        {
            try
            {
                var sql = @"                
                INSERT INTO [dbo].[Clientes]
                    (Nome, Email, CPF, Phone, Data_Registro, Data_Atualizacao)
                SELECT DISTINCT 
                    Ca.buyer_name, Ca.buyer_email, Ca.cpf, Ca.buyer_phone_number, GETDATE(), GETDATE()
                FROM Carga Ca
                LEFT JOIN [Clientes] Cl ON Cl.CPF = Ca.cpf
                WHERE Cl.CPF IS NULL
                ";
                
                var resp = _dbContext.Database.ExecuteSqlRaw(sql);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante a operação em Clientes: " + ex.Message);
            }
        }

        public static bool ExecutarProcedimento()
        {
            bool clientes = PopularClientes();
            bool produtos = PopularProdutos();
            if (clientes && produtos)
            {
                return true;
            }

            return false;
        }
    }

}