using BazarTemTudo.Domain.Entities;
using BazarTemTudo.InfraData.Configuration;
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
    public class SQLiteContext : IdentityDbContext<Usuarios>
    {
        public SQLiteContext(DbContextOptions<IdentityDbContext<Usuarios>> options) : base(options)
        {
        }

        public SQLiteContext(DbContextOptions options) : base(options)
        {
        }

        
         public DbSet<Checkout> Checkout { get; set; }
         public DbSet<Clientes> Clientes { get; set; }
         public DbSet<DespachoMercadorias> DespachoMercadorias { get; set; }
         public DbSet<Endereco> Enderecos { get; set; }
         public DbSet<Estoque> Estoque { get; set; }
         public DbSet<Fornecedores> Fornecedores { get; set; }
         public DbSet<ItensPedidos> ItensPedidos { get; set; }
         public DbSet<NotaFiscal> NotaFiscais { get; set; }
         public DbSet<Pedidos> Pedidos { get; set; }
         public DbSet<Produtos> Produtos { get; set; }
         public DbSet<RequisicaoCompra> RequisicaoCompras { get; set; }
         public DbSet<Transportadoras> Transportadoras { get; set; }  


        public DbSet<Usuarios> Usuarios { get; set; }

    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
           
            modelBuilder.ApplyConfiguration(new ClientesConfig());
            modelBuilder.ApplyConfiguration(new CheckoutConfig());
            modelBuilder.ApplyConfiguration(new DespachoMercadoriasConfig());
            modelBuilder.ApplyConfiguration(new EnderecosConfig());
            modelBuilder.ApplyConfiguration(new EstoqueConfig());
            modelBuilder.ApplyConfiguration(new FornecedoresConfig());
            modelBuilder.ApplyConfiguration(new ItensPedidosConfig());
            modelBuilder.ApplyConfiguration(new NotaFiscalConfig());
            modelBuilder.ApplyConfiguration(new PedidosConfig());
            modelBuilder.ApplyConfiguration(new ProdutosConfig());
            modelBuilder.ApplyConfiguration(new RequisicaoCompraConfig());
            modelBuilder.ApplyConfiguration(new TransportadorasConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
         

            modelBuilder.Entity<Notification>().HasNoKey();

         
            modelBuilder.Entity<Checkout>().Ignore(a => a.Notifications);
            modelBuilder.Entity<Clientes>().Ignore(a => a.Notifications);
            modelBuilder.Entity<DespachoMercadorias>().Ignore(a => a.Notifications);
            modelBuilder.Entity<Endereco>().Ignore(a => a.Notifications);
            modelBuilder.Entity<Estoque>().Ignore(a => a.Notifications);
            modelBuilder.Entity<Fornecedores>().Ignore(a => a.Notifications);
            modelBuilder.Entity<ItensPedidos>().Ignore(a => a.Notifications);
            modelBuilder.Entity<NotaFiscal>().Ignore(a => a.Notifications);
            modelBuilder.Entity<Pedidos>().Ignore(a => a.Notifications);
            modelBuilder.Entity<Produtos>().Ignore(a => a.Notifications);
            modelBuilder.Entity<RequisicaoCompra>().Ignore(a => a.Notifications);
            modelBuilder.Entity<Transportadoras>().Ignore(a => a.Notifications);  

            base.OnModelCreating(modelBuilder);
        }



    }
}
