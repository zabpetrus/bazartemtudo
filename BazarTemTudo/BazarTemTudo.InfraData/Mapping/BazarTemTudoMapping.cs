using AutoMapper;
using BazarTemTudo.Application.ViewModels;
using BazarTemTudo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.InfraData.Mapping
{
    public class BazarTemTudoMapping : Profile
    {
        public BazarTemTudoMapping()
        {
            CreateMap<Clientes, ClientesViewModel>();
            CreateMap<ClientesViewModel, Clientes>();
            CreateMap<Carga, CargaViewModel>();
            CreateMap<CargaViewModel, Carga>();
            CreateMap<Produtos, ProdutosViewModel>();
            CreateMap<ProdutosViewModel, Produtos>();
            CreateMap<NotaFiscal, NotaFiscalViewModel>();
            CreateMap<NotaFiscalViewModel, NotaFiscal>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<Estoque, EstoqueViewModel>();
            CreateMap<EstoqueViewModel, Estoque>();
            CreateMap<Pedidos, PedidosViewModel>();
            CreateMap<PedidosViewModel, Pedidos>();
            CreateMap<Perfil, PerfilUsuarioViewModel>();
            CreateMap<PerfilUsuarioViewModel, Perfil>();
            CreateMap<RequisicaoCompra, RequisicaoCompraViewModel>();
            CreateMap<RequisicaoCompraViewModel, RequisicaoCompra>();
            CreateMap<Transportadoras, TransportadorasViewModel>();
            CreateMap<TransportadorasViewModel, Transportadoras>();
            CreateMap<DespachoMercadorias, DespachoMercadoriasViewModel>();
            CreateMap<DespachoMercadoriasViewModel, DespachoMercadorias>();
            CreateMap<Checkout, CheckoutViewModel>();
            CreateMap<CheckoutViewModel, Checkout>();
            CreateMap<Usuarios, UsuariosViewModel>();
            CreateMap<UsuariosViewModel, Usuarios>();
            CreateMap<UsuarioExterno, UsuariosViewModel>();
            CreateMap<UsuariosViewModel, UsuarioExterno>();
            CreateMap<UsuariosViewModel, UsuarioInterno>();
            CreateMap<UsuarioInterno, UsuariosViewModel>();
            CreateMap<Fornecedores, FornecedoresViewModel>();
            CreateMap<FornecedoresViewModel, Fornecedores>();

        }
    }
}
