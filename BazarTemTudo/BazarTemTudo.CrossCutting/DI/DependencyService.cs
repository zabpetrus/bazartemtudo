using Autofac.Core;
using BazarTemTudo.Application.AppService;
using BazarTemTudo.Application.Interface;
using BazarTemTudo.CrossCutting.Service;
using BazarTemTudo.Domain.Interface.Repository;
using BazarTemTudo.Domain.Interface.Service;
using BazarTemTudo.Domain.Service;
using BazarTemTudo.InfraData.Repository;
using BazarTemTudo.InfraData.UnitOfWork;
using BazarTemTudo.TesteConsole.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.CrossCutting.DI
{
    public class DependencyService
    {
        public static void RegisterDependencies(IConfiguration configuration, IServiceCollection services)
        {
            RegisterRepositories(services);
            RegisterServices(services);
            RegisterApplicationServices(services);
            GeneralRegister(services);  
        }

        private static void RegisterApplicationServices(IServiceCollection services)
        {
            services.AddScoped<IClientesAppService, ClientesAppService>();
            services.AddScoped<ICheckoutAppService, CheckoutAppService>();
            services.AddScoped<IDespachoMercadoriasAppService, DespachoMercadoriasAppService>();
            services.AddScoped<IEstoqueAppService, EstoqueAppService>();
            services.AddScoped<IFornecedoresAppService, FornecedoresAppService>();  
            services.AddScoped<IItensPedidosAppService, ItensPedidosAppService>();
            services.AddScoped<IPedidoAppService, PedidosAppService>();
            services.AddScoped<IPerfilUsuarioAppService, PerfilUsuarioAppService>();
            services.AddScoped<IProdutosAppService, ProdutosAppService>();  
            services.AddScoped<IRequisicaoCompraAppService, RequisicaoCompraAppService>();
            services.AddScoped<ITransportadorasAppService, TransportadorasAppService>();
            services.AddScoped<IUsuariosAppService, UsuariosAppService>();
            services.AddScoped<IEnderecoAppService, EnderecoAppService>();


        }
        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IClientesService, ClientesService>();
            services.AddScoped<ICheckoutService, CheckoutService>();
            services.AddScoped<IDespachoMercadoriasService, DespachoMercadoriasService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<IFornecedoresService, FornecedoresService>();
            services.AddScoped<IItensPedidosService, ItensPedidosService>();
            services.AddScoped<IPedidosService, PedidosService>();
            services.AddScoped<IPerfilService, PerfilService>();
            services.AddScoped<IProdutosService, ProdutosService>();
            services.AddScoped<IRequisicaoCompraService, RequisicaoCompraService>();
            services.AddScoped<ITransportadorasService, TransportadorasService>();
            services.AddScoped<IUsuarioService, UsuariosService>();
            services.AddScoped<IEnderecoService, EnderecoService>();

        }
        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IClientesRepository, ClientesRepository>();
            services.AddScoped<ICheckoutRepository, CheckoutRepository>();
            services.AddScoped<IDespachoMercadoriasRepository, DespachoMercadoriasRepository>();
            services.AddScoped<IEstoqueRepository, EstoqueRepository>();
            services.AddScoped<IFornecedoresRepository, FornecedoresRepository>();
            services.AddScoped<IItensPedidosRepository, ItensPedidosRepository>();
            services.AddScoped<IPedidosRepository, PedidosRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IProdutosRepository, ProdutosRepository>();
            services.AddScoped<IRequisicaoCompraRepository, RequisicaoCompraRepository>();
            services.AddScoped<ITransportadorasRepository, TransportadorasRepository>();
            services.AddScoped<IUsuarioRepository, UsuariosRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
        }

        private static void GeneralRegister(IServiceCollection services)
        {
            services.AddScoped<CargaService>();
            services.AddScoped<PopulationService>();
        }

 
    }
}
