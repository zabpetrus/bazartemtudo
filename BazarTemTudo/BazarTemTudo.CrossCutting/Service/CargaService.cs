using BazarTemTudo.Application.ViewModels;
using BazarTemTudo.Domain.Entities;
using BazarTemTudo.Domain.Entities.Enums;
using BazarTemTudo.InfraData.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BazarTemTudo.CrossCutting.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Http.HttpResults;
    using Microsoft.EntityFrameworkCore;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

    public class CargaService
    {
        private readonly ApplicationDBContext _dbContext;

        public CargaService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        private void PopularClientes(List<CargaViewModel> result)
        {
            try
            {
                var clientes = result
               .Where(ca => ca.buyer_name != null)
               .Select(ca => new Clientes
               {
                   Nome = ca.buyer_name,
                   Email = ca.buyer_email,
                   CPF = ca.cpf,
                   Phone = ca.buyer_phone_number
               })
               .GroupBy(c => c.CPF) // Agrupa pelos nomes
               .Select(g => g.First()) // Seleciona o primeiro cliente de cada grupo (distinto pelo nome)
               .ToList();

                var cpfsExistem = _dbContext.Clientes
                     .Any(c => clientes.Select(cliente => cliente.CPF).Contains(c.CPF));

                if (!cpfsExistem)
                {
                    _dbContext.Clientes.AddRange(clientes);
                    _dbContext.SaveChanges();
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao popular a tabela Clientes.", ex);
            }
        }


        private void PopularProdutos(List<CargaViewModel> result)
        {
            try
            {
                 var produtos = result.Where(carga => carga.upc !=  null)
                    .Select(carga => new Produtos
                    {
                        NomeProduto = carga.product_name,
                        SKU = carga.sku,
                        UPC = carga.upc,
                        Valor = carga.item_price
                    })
                    .GroupBy(c => c.UPC)
                    .Select(g => g.First())
                    .ToList();

                var produtosExistem = _dbContext.Produtos
                    .Any(c => produtos.Select(produto => produto.UPC).Contains(c.UPC));

                if (!produtosExistem)
                {
                     _dbContext.Produtos.AddRange(produtos);
                    _dbContext.SaveChanges();
                
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao popular a tabela Produtos.", ex);
            }

        }

        private void PopularEnderecos(List<CargaViewModel> result)
        {
            try
            {
                var enderecos = result
                    .Where(ca => !string.IsNullOrEmpty(ca.order_id))
                    .Select(ca => new Endereco
                    {
                        Order_id = ca.order_id,
                        Ship_address1 = ca.ship_address_1,
                        Ship_address2 = ca.ship_address_2,
                        Ship_address3 = ca.ship_address_3,
                        Ship_city = ca.ship_city,
                        Ship_state = ca.ship_state,
                        Ship_postal_code = ca.ship_postal_code,
                        Ship_country = ca.ship_country
                    })
                    .GroupBy(e => e.Order_id)  // Agrupa pelos Order_id para garantir distinção
                    .Select(g => g.First())    // Seleciona o primeiro endereço de cada grupo (distinto pelo Order_id)
                    .ToList();

                var orderIdsExistem = _dbContext.Enderecos
                    .Any(e => enderecos.Select(endereco => endereco.Order_id).Contains(e.Order_id));

                if (!orderIdsExistem)
                {
                       _dbContext.Enderecos.AddRange(enderecos);
                        _dbContext.SaveChanges();
                }

              
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao popular a tabela Enderecos.", ex);
            }
        }


       
        private void PopularPedidos(List<CargaViewModel> result)
        {
            try
            {
                var pedidos = (from ca in result
                             join cli in _dbContext.Clientes on ca.cpf equals cli.CPF into clienteGroup
                             from cli in clienteGroup.DefaultIfEmpty()
                             join pe in _dbContext.Pedidos on ca.order_id equals pe.Order_id into pedidoGroup
                             from pe in pedidoGroup.DefaultIfEmpty()
                             join en in _dbContext.Enderecos on ca.order_id equals en.Order_id into enderecoGroup
                             from en in enderecoGroup.DefaultIfEmpty()
                             where pedidoGroup.All(p => p == null)  // Equivalent to NOT EXISTS subquery
                             select new Pedidos
                             {
                                 Order_id = ca.order_id,
                                 Purchase_Date = ca.purchase_date,
                                 Payments_Date = ca.payments_date,
                                 Currency = ca.currency,
                                 Ship_service_level = ca.ship_service_level,
                                 statusPedido = StatusPedido.Pendente,
                                 Endereco_Id = en.Id,  // Assuming Endereco_Id is the primary key of Enderecos
                                 ClientesId = cli.Id
                               
                             }).Distinct()
                              .GroupBy(e => e.Order_id)  // Agrupa pelos Order_id para garantir distinção
                               .Select(g => g.First())    // Seleciona o primeiro endereço de cada grupo (distinto pelo Order_id)
                               .ToList();
    

                var ped = _dbContext.Pedidos
                        .Any(p => pedidos.Select(pedido => pedido.Order_id).Contains(p.Order_id));

                if (!ped)
                {
                     _dbContext.Pedidos.AddRange(pedidos);
                     _dbContext.SaveChanges();
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao popular a tabela Pedidos.", ex);
            }
        }


        private void PopularItensPedidos(List<CargaViewModel> result)
        {
            try
            {
                var query = (
                            from ca in result
                            join pe in _dbContext.Pedidos on ca.order_id equals pe.Order_id into peGroup
                            from pe in peGroup.DefaultIfEmpty()
                            join pr in _dbContext.Produtos on new { UPC= ca.upc, SKU = ca.sku } equals new { pr.UPC, pr.SKU } into prGroup
                            from pr in prGroup.DefaultIfEmpty()
                            where pe != null && pr != null && ! _dbContext.ItensPedidos.Any(d =>
                                d.PedidoId == pe.Id &&
                                d.ProdutoId == pr.Id &&
                                d.Order_Item_id == ca.order_item_id
                            )
                            select new ItensPedidos
                             {
                                 PedidoId = pe.Id,
                                 ProdutoId = pr.Id,
                                 Order_Item_id = ca.order_item_id,
                                 Item_Price = ca.item_price,
                                 Quantity_Purchased = ca.quantity_purchased

                             });


                _dbContext.ItensPedidos.AddRange(query);
                _dbContext.SaveChanges();


            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao popular a tabela ItensPedido.", ex);
            }
        }



        public bool PopulateTables(List<CargaViewModel> result)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    //Tabelas Essenciais

                    PopularClientes(result);
                    
                    PopularProdutos(result);

                    PopularEnderecos(result);  
                    
                    PopularPedidos(result);
                  
                    PopularItensPedidos(result);

                    transaction.Commit(); 
                    
                    return true;
                    
                }
                catch (Exception ex) {

                    return false;
                }
            }
           
        }

       



        public void PopularEstoque()
        {
            try
            {
                var produtosNaTabelaEstoque = _dbContext.Estoque
                    .Select(e => e.ProdutosID)
                    .ToList();

                var produtosParaInserir = _dbContext.Produtos
                    .Where(p => !produtosNaTabelaEstoque.Contains(p.Id))
                    .ToList();

                var novosEstoques = produtosParaInserir
                    .Select(produto => new Estoque
                    {
                        ProdutosID = produto.Id,
                        Quantidade = 0,
                        Estoque_Minimo = 0, // Defina o valor inicial desejado para Estoque_Minimo
                        
                    })
                    .ToList();

                _dbContext.Estoque.AddRange(novosEstoques);
                _dbContext.SaveChanges();

                Console.WriteLine("Estoques populados com sucesso!");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao popular o estoque.", ex);
            }
        }
    }

}


