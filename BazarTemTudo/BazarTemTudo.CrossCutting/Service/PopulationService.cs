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
            if (_dbContext == null)
            {
                throw new Exception("Contexto nulo. Não posso continuar");
            }

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
                            Telefone = "(11) 1234-5678",
                            Email = "fornecedor_a@example.com",
                            Website = "www.fornecedora.com",

                        },
                        new Fornecedores
                        {
                            Nome_Fornecedor = "Fornecedor B",
                            CNPJ = "98.765.432/0001-02",
                            Telefone = "(21) 9876-5432",
                            Email = "fornecedor_b@example.com",
                            Website = "www.fornecedorb.com",

                        },
                        new Fornecedores
                        {
                            Nome_Fornecedor = "Fornecedor C",
                            CNPJ = "11.222.333/0001-03",
                            Telefone = "(31) 1122-3344",
                            Email = "fornecedor_c@example.com",
                            Website = "www.fornecedorc.com",

                        },
                        new Fornecedores
                        {
                            Nome_Fornecedor = "Fornecedor D",
                            CNPJ = "44.555.666/0001-04",
                            Telefone = "(41) 4455-6666",
                            Email = "fornecedor_d@example.com",
                            Website = "www.fornecedord.com",

                        },
                        new Fornecedores
                        {
                            Nome_Fornecedor = "Fornecedor E",
                            CNPJ = "77.888.999/0001-05",
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

        private List<ConsultaDTO> ListaPedidosOrganizada()
        {
          
            // Passo 1: Obter a lista de pedidos com os itens e seus totais
            var pedidoTotais = from tp in _dbContext.ItensPedidos
                               group tp by new { tp.Id, tp.PedidoId, tp.Pedido.Purchase_Date } into grouped
                               select new
                               {
                                   ItemPedidoID = grouped.Key.Id,
                                   PedidoID = grouped.Key.PedidoId,
                                   SOMA = grouped.Sum(tp => tp.Item_Price * tp.Quantity_Purchased),
                                   Prioridade = grouped.Key.Purchase_Date
                               };

            var pedidosComItens = from pt in pedidoTotais
                                  join ipx in _dbContext.ItensPedidos on pt.PedidoID equals ipx.PedidoId
                                  orderby pt.SOMA descending, pt.Prioridade descending, ipx.ProdutoId
                                  select new ConsultaDTO
                                  {
                                      ItemPedidoId = ipx.Id,
                                      PedidoId = pt.PedidoID,
                                      ProdutoId = ipx.ProdutoId,
                                      QuantidadeComprada = ipx.Quantity_Purchased,
                                      Disponivel = ipx.Disponivel,
                                      Soma = pt.SOMA,
                                      Prioridade = pt.Prioridade
                                  };

            var result = pedidosComItens.ToList();
            return result;
        }   

        private void VendoDisponibilidade(List<ConsultaDTO> result )
        {
            // Passo 4: Atualizar a disponibilidade dos itens de pedido e o estoque
            foreach (var item in result)
            {
                //Achando no estoque o correspondente produto
                var estoque = _dbContext.Estoque.FirstOrDefault(e => e.ProdutosID == item.ProdutoId);

                //Verificando se o estoque é maior ou menor que o item do pedido
                if (estoque != null && estoque.Quantidade >= item.QuantidadeComprada)
                {
                    // Atualize a disponibilidade do item de pedido
                    var itemPedido = _dbContext.ItensPedidos.FirstOrDefault(ip => ip.PedidoId == item.PedidoId && ip.ProdutoId == item.ProdutoId);

                    if (itemPedido != null)
                    {
                        itemPedido.Disponivel = true;
                        _dbContext.Update(itemPedido);
                    }

                    // Atualize a quantidade no estoque
                    estoque.Quantidade -= item.QuantidadeComprada;
                    _dbContext.Update(estoque);
                }
            }
        }




        public void PrimeirosProcedimentos()
        {
            var result = ListaPedidosOrganizada();

            List<ItemProdutoDTO> itensPorProduto = result
                .GroupBy(x => x.ProdutoId)
                .Select(g => new ItemProdutoDTO
                {
                    ProdutoId = g.Key,
                    QuantidadeTotalComprada = g.Sum(x => x.QuantidadeComprada)
                })
                .ToList();

            //Verificar se é necessaria uma nova requisicao

            var requisicaoCompraCriada = VerificarNovaRequisicaoCompra(itensPorProduto);


            // Passo 3: Se uma requisição de compra foi criada, não atualize o estoque nem a disponibilidade dos itens de pedido
            if (!requisicaoCompraCriada)
            {
                VendoDisponibilidade(result);
                Checkout();
            }

            // Salve as alterações no contexto
            _dbContext.SaveChanges();


        }

        private bool VerificarNovaRequisicaoCompra(List<ItemProdutoDTO> itensPorProduto)
        {
            bool requisicaoCompraCriada = false;

            
            // Verifique se existe um fornecedor disponível
            var fornecedor = _dbContext.Fornecedores.FirstOrDefault();

            if(itensPorProduto.Count <= 0  || itensPorProduto == null)
            {
                throw new Exception("Itens Produtos nulo");
            }
         
            if (fornecedor == null)
            {
                throw new Exception("Sem nenhum Fornecedor disponível");
            }

            // Verifique se a quantidade necessária está disponível no estoque para cada produto
            foreach (var item in itensPorProduto)
            {
                var estoque_prod = _dbContext.Estoque.FirstOrDefault(e => e.ProdutosID == item.ProdutoId);

                   if (estoque_prod == null || estoque_prod.Quantidade < item.QuantidadeTotalComprada)
                    {
                        // Se a quantidade no estoque for insuficiente, crie uma RequisicaoCompra
                        RequisicaoCompra requisicaoCompra = new()
                        {
                            Fornecedor_ID = fornecedor.Id,
                            Produto_ID = item.ProdutoId,
                            Quantidade = item.QuantidadeTotalComprada,
                            Status_Pedido = StatusPedido.Pendente,
                            Total_Compra = 100,
                            Data_Emissao = DateTime.Now
                        };

                        _dbContext.RequisicoesCompra.Add(requisicaoCompra);  
                        _dbContext.SaveChanges();
                        requisicaoCompraCriada = true;
                    }                
              
                
            }

           
            return requisicaoCompraCriada;
        }






        public void VerificarEPopularRequisicaoCompra()
        {
            if (_dbContext.Estoque.Any())
            {
                 PrimeirosProcedimentos();   
            }                      
        }

        public void Checkout()
        {
            try
            {
                // Verifica se a tabela checkout está vazia
                bool isCheckoutTableEmpty = !_dbContext.Checkout.Any();

                if (isCheckoutTableEmpty)
                {
                    // Se vazia, insere os registros de checkout
                    var query = from tp in _dbContext.ItensPedidos
                                join pe in _dbContext.Pedidos on tp.PedidoId equals pe.Id
                                group new { tp, pe } by new { pe.Id, pe.Purchase_Date } into g
                                orderby g.Sum(x => x.tp.Item_Price * x.tp.Quantity_Purchased) descending, g.Key.Purchase_Date descending
                                select new Checkout
                                {
                                    Total_Pedido = g.Sum(x => x.tp.Item_Price * x.tp.Quantity_Purchased),
                                    Status_Despacho = StatusDespacho.Em_processamento,
                                    DataDespacho = DateTime.Now,
                                    PedidoId = g.Key.Id
                                };

                    var result = query.ToList();
                    _dbContext.AddRange(result);
                    _dbContext.SaveChanges();
                }
                else
                {
                    // Se não estiver vazia, verifica pedidos prontos e atualiza status de despacho

                    VerificarEPopularRequisicaoCompra();

                    var pedidosProntos = VerificarPedidosProntos();

                    if (pedidosProntos != null && pedidosProntos.Any())
                    {
                        foreach (var pedido in pedidosProntos)
                        {
                            // Atualiza o status de despacho para Pronto para envio
                            var checkoutItems = _dbContext.Checkout.Where(o => o.PedidoId == pedido.Id);
                            foreach (var item in checkoutItems)
                            {
                                item.Status_Despacho = StatusDespacho.Pronto_para_envio;
                            }

                            var produtosProntosParaEnvio = checkoutItems
                                .Select(o => new DespachoMercadorias
                                {
                                    Pedido_Id = o.PedidoId,
                                    Transportadora_ID = 1, // Sempre ID da transportadora 1
                                    Status_Entrega = StatusDespacho.Pronto_para_envio,
                                    Data_Liberacao = DateTime.Now,
                                })
                                .ToList();

                            _dbContext.DespachoMercadorias.AddRange(produtosProntosParaEnvio);
                        }

                        _dbContext.SaveChanges(); // Salva as alterações no banco de dados
                    }
                    else
                    {
                        throw new Exception("Não há pedidos prontos!");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro durante o checkout: " + ex.Message, ex);
            }
        }


        public void AtualizarEstoque()
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var pedidoTotais = from tp in _dbContext.ItensPedidos
                                       group tp by new { tp.PedidoId, tp.Pedido.Purchase_Date } into grouped
                                       select new
                                       {
                                           PedidoID = grouped.Key.PedidoId,
                                           SOMA = grouped.Sum(tp => tp.Item_Price * tp.Quantity_Purchased),
                                           Prioridade = grouped.Key.Purchase_Date
                                       };

                    var pedidosComItens = from pt in pedidoTotais
                                          join ipx in _dbContext.ItensPedidos on pt.PedidoID equals ipx.PedidoId
                                          orderby pt.SOMA descending, pt.Prioridade descending, ipx.ProdutoId
                                          select new
                                          {
                                              ipx.Id,
                                              ipx.PedidoId,
                                              ipx.ProdutoId,
                                              ipx.Quantity_Purchased,
                                              ipx.Disponivel,
                                              pt.SOMA,
                                              pt.Prioridade
                                          };

                    foreach (var item in pedidosComItens)
                    {
                        var res = _dbContext.Estoque.FirstOrDefault(e => e.ProdutosID == item.ProdutoId);
                        if (res != null)
                        {
                            if (res.Quantidade >= item.Quantity_Purchased)
                            {
                                res.Quantidade -= item.Quantity_Purchased;

                                var founded = _dbContext.ItensPedidos.Find(item.Id);
                                if (founded != null)
                                {
                                    founded.Disponivel = true;
                                    _dbContext.ItensPedidos.Update(founded);
                                    _dbContext.Estoque.Update(res);
                                }
                                else
                                {
                                    throw new Exception("Erro durante a operação: Produto não encontrado");
                                }
                            }
                            else
                            {
                                // Se o estoque não for suficiente para este item, para o processamento
                                break;
                            }
                        }
                        else
                        {
                            throw new Exception("Produto não encontrado no estoque");
                        }
                    }

                    _dbContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro durante a atualização do estoque: " + ex.Message, ex);
                }
            }
        }




        public List<Pedidos> VerificarPedidosProntos()
        {
            try
            {
               var res = _dbContext.Pedidos
                .Where(pedido => pedido.ItensPedidos.All(ip => ip.Disponivel))
                .ToList();
                if (res.Any())
                {
                    return res;
                }
                else
                {
                    throw new Exception("Não tem pedidos prontos!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }             
        }


    }                                
}
