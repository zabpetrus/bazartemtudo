using BazarTemTudo.Domain.Entities.Enums;
using BazarTemTudo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BazarTemTudo.InfraData.Context;

namespace BazarTemTudo.CrossCutting.Service
{
    public class ProceduresPopulation
    {

        private readonly ApplicationDBContext _dbContext;

        public ProceduresPopulation(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
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





        private void AnalisarEstoque()
        {
            var requisicoesCompra = new List<RequisicaoCompra>();

            var estoque = _dbContext.Estoque.ToList();

            foreach (var e in estoque)
            {
                if (e.Quantidade == 0)
                {
                    var requisicao = new RequisicaoCompra()
                    {
                        Produto_ID = e.ProdutosID,
                        Fornecedor_ID = 1,
                        Status_Pedido = StatusPedido.Pendente,
                        Quantidade = e.Estoque_Minimo * 10,
                        Total_Compra = 100,
                        Data_Emissao = DateTime.Now // Certifique-se de definir a Data_Emissao
                    };

                    requisicoesCompra.Add(requisicao);
                }
            }

            if (requisicoesCompra.Any())
            {
                _dbContext.RequisicoesCompra.AddRange(requisicoesCompra);
                _dbContext.SaveChanges();
            }
        }

    }

    
}
