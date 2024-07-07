using BazarTemTudo.Domain.Entities;
using BazarTemTudo.InfraData.Context.Configuration;
using Flunt.Notifications;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.InfraData.Context
{
    public class ApplicationDBContext : IdentityDbContext<Usuarios>
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }


        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Checkout> Checkout { get; set; }
        public DbSet<DespachoMercadorias> DespachoMercadorias { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Fornecedores> Fornecedores { get; set; }
        public DbSet<ItensPedidos> ItensPedidos { get; set; }
        public DbSet<NotaFiscal> NotasFiscais { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<RequisicaoCompra> RequisicoesCompra { get; set; }
        public DbSet<Transportadoras> Transportadoras { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();


            modelBuilder.ApplyConfiguration(new CheckoutConfig());
            modelBuilder.ApplyConfiguration(new ClientesConfig());
            modelBuilder.ApplyConfiguration(new DespachoMercadoriasConfig());
            modelBuilder.ApplyConfiguration(new EnderecosConfig());
            modelBuilder.ApplyConfiguration(new FornecedoresConfig());
            modelBuilder.ApplyConfiguration(new ItensPedidosConfig());
            modelBuilder.ApplyConfiguration(new NotaFiscalConfig());
            modelBuilder.ApplyConfiguration(new PedidosConfig());
            modelBuilder.ApplyConfiguration(new PerfilConfig());
            modelBuilder.ApplyConfiguration(new ProdutosConfig());
            modelBuilder.ApplyConfiguration(new RequisicaoCompraConfig());
            modelBuilder.ApplyConfiguration(new TransportadorasConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());

          

            //modelBuilder.Entity<Carga>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }



    }
}
