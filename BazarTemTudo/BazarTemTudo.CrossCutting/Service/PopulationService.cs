using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Entities.Enums;
using BazarTemTudo.InfraData.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.CrossCutting.Service
{
    public class PopulationService
    {
        private readonly ApplicationDBContext _dbContext;

        public PopulationService(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
            _dbContext.Database.ExecuteSqlRaw("TRUNCATE TABLE [Estoque]");

        }

        public void SeedEstoqueVazio()
        {
            try
            {                
                var query =
                    from oi in _dbContext.ItensPedidos
                    join it in _dbContext.Estoque on oi.ProdutoId equals it.ProdutosID into itGroup
                    from it in itGroup.DefaultIfEmpty()
                    where !_dbContext.Estoque.Any(e => e.ProdutosID == oi.ProdutoId)
                    group oi by oi.ProdutoId into grouped
                    select new Estoque
                    {
                        ProdutosID = grouped.Key,
                        Quantidade = 0,
                        Estoque_Minimo = grouped.Sum(g => g.Quantity_Purchased)
                    };

                var result = query.ToList();

                _dbContext.Estoque.AddRange(result);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro na populacao de Estoque:" + ex);
                
            }

        }


        public void SeedEstoqueAbastecido()
        {
            try
            {
                 var query =
                    from oi in _dbContext.ItensPedidos
                    join it in _dbContext.Estoque on oi.ProdutoId equals it.ProdutosID into itGroup
                    from it in itGroup.DefaultIfEmpty()
                    where !_dbContext.Estoque.Any(e => e.ProdutosID == oi.ProdutoId)
                    group oi by oi.ProdutoId into grouped
                    select new Estoque
                    {
                        ProdutosID = grouped.Key,
                        Quantidade = 100,
                        Estoque_Minimo = grouped.Sum(g => g.Quantity_Purchased)
                    };

                var result = query.ToList();

                _dbContext.Estoque.AddRange(result);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro na populacao de Estoque:" + ex);

            }
        }



        public void SeedEstoqueVariado()
        {
            try
            {
                
                var random = new Random();
                var query =
                    from oi in _dbContext.ItensPedidos
                    join it in _dbContext.Estoque on oi.ProdutoId equals it.ProdutosID into itGroup
                    from it in itGroup.DefaultIfEmpty()
                    where !_dbContext.Estoque.Any(e => e.ProdutosID == oi.ProdutoId)
                    group oi by oi.ProdutoId into grouped
                    select new Estoque
                    {
                        ProdutosID = grouped.Key,
                        Quantidade = random.Next(1, 100),
                        Estoque_Minimo = grouped.Sum(g => g.Quantity_Purchased)
                    };

                var result = query.ToList();

                _dbContext.Estoque.AddRange(result);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro na populacao de Estoque:" + ex);

            }
        }


        public void PopularFornecedores()
        {
            try
            {
                bool tabelaVazia = !_dbContext.Fornecedores.Any();

                if (tabelaVazia)
                {
                    var fornecedores = new List<Fornecedores>       
                    {
                        new Fornecedores
                        {
                            Nome_Fornecedor = "Fornecedor A",
                            CNPJ = "12.345.678/0001-01",
                            Endereco_ID = 1,
                            Telefone = "(11) 1234-5678",
                            Email = "fornecedor_a@example.com",
                            Website = "www.fornecedora.com",

                        },
                        new Fornecedores
                        {
                            Nome_Fornecedor = "Fornecedor B",
                            CNPJ = "98.765.432/0001-02",
                            Endereco_ID = 2,
                            Telefone = "(21) 9876-5432",
                            Email = "fornecedor_b@example.com",
                            Website = "www.fornecedorb.com",

                        },
                        new Fornecedores
                        {
                            Nome_Fornecedor = "Fornecedor C",
                            CNPJ = "11.222.333/0001-03",
                            Endereco_ID = 3,
                            Telefone = "(31) 1122-3344",
                            Email = "fornecedor_c@example.com",
                            Website = "www.fornecedorc.com",

                        },
                        new Fornecedores
                        {
                            Nome_Fornecedor = "Fornecedor D",
                            CNPJ = "44.555.666/0001-04",
                            Endereco_ID = 4,
                            Telefone = "(41) 4455-6666",
                            Email = "fornecedor_d@example.com",
                            Website = "www.fornecedord.com",

                        },
                        new Fornecedores
                        {
                            Nome_Fornecedor = "Fornecedor E",
                            CNPJ = "77.888.999/0001-05",
                            Endereco_ID = 5,
                            Telefone = "(51) 7788-9999",
                            Email = "fornecedor_e@example.com",
                            Website = "www.fornecedore.com",

                        }
                    };

                    foreach (var fornecedor in fornecedores)
                    {
                        if (!_dbContext.Fornecedores.Any(f => f.CNPJ == fornecedor.CNPJ))
                        {
                            _dbContext.Fornecedores.Add(fornecedor);
                        }
                    }

                    _dbContext.SaveChanges();
                }                 
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na inserção de fornecedores: ", ex);
            }

        }


        public void PopularTransportadoras()
        {
            try
            {
                bool tabelaVazia = !_dbContext.Transportadoras.Any();
                if (tabelaVazia)
                {
                    var transportadoras = new List<Transportadoras>
                    {
                        new Transportadoras
                        {
                            NomeTransportadora = "Transportadora A",
                            CNPJ = "11.222.333/0001-01",
                            TipoServico = TipoServico.Normal,
                            Shipping = Shipping.Standard_Shipping,
                            CustoFrete = 50.00m,                           
                        },
                        new Transportadoras
                        {
                            NomeTransportadora = "Transportadora B",
                            CNPJ = "22.333.444/0001-02",
                            TipoServico = TipoServico.Normal,
                            Shipping = Shipping.Standard_Shipping,
                            CustoFrete = 75.00m,                          
                        },
                        new Transportadoras
                        {
                            NomeTransportadora = "Transportadora C",
                            CNPJ = "33.444.555/0001-03",
                            TipoServico = TipoServico.Economico,
                            Shipping = Shipping.Standard_Shipping,
                            CustoFrete = 60.00m
                            
                        },
                        new Transportadoras
                        {
                            NomeTransportadora = "Transportadora D",
                            CNPJ = "44.555.666/0001-04",
                            TipoServico = TipoServico.Normal,
                            Shipping = Shipping.Express_Shipping,
                            CustoFrete = 50.00m                            
                        },
                        new Transportadoras
                        {
                            NomeTransportadora = "Transportadora E",
                            CNPJ = "55.666.777/0001-05",
                            TipoServico = TipoServico.Expresso,
                            Shipping = Shipping.Express_Shipping,
                            CustoFrete = 90.00m,
                          
                        }
                    };

                    foreach (var transportadora in transportadoras)
                    {
                        if (!_dbContext.Transportadoras.Any(t => t.CNPJ == transportadora.CNPJ))
                        {
                            _dbContext.Transportadoras.Add(transportadora);
                        }
                    }

                    _dbContext.SaveChanges();
                }
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }


        public void PopularRequisicaoCompra()
        {

        }


    }                                
}
