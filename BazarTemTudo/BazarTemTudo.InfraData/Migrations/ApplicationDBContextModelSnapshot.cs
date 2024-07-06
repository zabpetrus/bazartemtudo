﻿// <auto-generated />
using System;
using BazarTemTudo.InfraData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BazarTemTudo.InfraData.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BazarTemTudo.Domain.Entities.Checkout", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DataDespacho")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_Atualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_Registro")
                        .HasColumnType("datetime2");

                    b.Property<long>("PedidoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Status_Despacho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Total_Pedido")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId")
                        .IsUnique();

                    b.ToTable("Checkout", (string)null);
                });

            modelBuilder.Entity("BazarTemTudo.Domain.Entities.Clientes", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Data_Atualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_Registro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("BazarTemTudo.Domain.Entities.DespachoMercadorias", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Data_Atualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_Liberacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_Registro")
                        .HasColumnType("datetime2");

                    b.Property<long>("Pedido_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Status_Entrega")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Transportadora_ID")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Pedido_Id");

                    b.HasIndex("Transportadora_ID");

                    b.ToTable("DespachoMercadorias", (string)null);
                });

            modelBuilder.Entity("BazarTemTudo.Domain.Entities.Endereco", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Data_Atualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_Registro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Order_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ship_address1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Ship_address2")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Ship_address3")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Ship_city")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ship_country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ship_postal_code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Ship_state")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Enderecos", (string)null);
                });

            modelBuilder.Entity("BazarTemTudo.Domain.Entities.Estoque", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Data_Atualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_Registro")
                        .HasColumnType("datetime2");

                    b.Property<int>("Estoque_Minimo")
                        .HasColumnType("int");

                    b.Property<long>("ProdutosID")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdutosID");

                    b.ToTable("Estoque");
                });

            modelBuilder.Entity("BazarTemTudo.Domain.Entities.Fornecedores", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data_Atualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_Registro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Endereco_ID")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome_Fornecedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Endereco_ID")
                        .IsUnique();

                    b.ToTable("Fornecedores", (string)null);
                });

            modelBuilder.Entity("BazarTemTudo.Domain.Entities.ItensPedidos", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Data_Atualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_Registro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bit");

                    b.Property<decimal>("Item_Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Order_Item_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PedidoId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProdutoId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity_Purchased")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ItensPedidos", (string)null);
                });

            modelBuilder.Entity("BazarTemTudo.Domain.Entities.NotaFiscal", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Data_Atualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_Emissao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_Registro")
                        .HasColumnType("datetime2");

                    b.Property<long>("PedidoID")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Valor_Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PedidoID")
                        .IsUnique();

                    b.ToTable("NotaFiscal", (string)null);
                });

            modelBuilder.Entity("BazarTemTudo.Domain.Entities.Pedidos", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ClientesId")
                        .HasColumnType("bigint");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data_Atualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_Registro")
                        .HasColumnType("datetime2");

                    b.Property<long>("Endereco_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Order_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Payments_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Purchase_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ship_service_level")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("statusPedido")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientesId");

                    b.HasIndex("Endereco_Id")
                        .IsUnique();

                    b.ToTable("Pedidos", (string)null);
                });

            modelBuilder.Entity("BazarTemTudo.Domain.Entities.Perfil", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Data_Atualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_Registro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Perfis", (string)null);
                });

            modelBuilder.Entity("BazarTemTudo.Domain.Entities.Produtos", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Data_Atualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_Registro")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UPC")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Produtos", (string)null);
                });

            modelBuilder.Entity("BazarTemTudo.Domain.Entities.RequisicaoCompra", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Data_Atualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_Emissao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_Registro")
                        .HasColumnType("datetime2");

                    b.Property<long>("Fornecedor_ID")
                        .HasColumnType("bigint");

                    b.Property<long>("Produto_ID")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<string>("Status_Pedido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Total_Compra")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Fornecedor_ID");

                    b.HasIndex("Produto_ID");

                    b.ToTable("RequisicaoCompra", (string)null);
                });

            modelBuilder.Entity("BazarTemTudo.Domain.Entities.Transportadoras", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CustoFrete")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Data_Atualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_Registro")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeTransportadora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Shipping")
                        .HasColumnType("int");

                    b.Property<int>("TipoServico")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Transportadoras", (string)null);
                });

            modelBuilder.Entity("BazarTemTudo.Domain.Entities.Usuarios", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BazarTemTudo.Domain.Entities.Checkout", b =>
                {
                    b.HasOne("BazarTemTudo.Domain.Entities.Pedidos", "Pedido")
                        .WithOne()
                        .HasForeignKey("BazarTemTudo.Domain.Entities.Checkout", "PedidoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("BazarTemTudo.Domain.Entities.DespachoMercadorias", b =>
                {
                    b.HasOne("BazarTemTudo.Domain.Entities.Pedidos", "Pedidos")
                        .WithMany()
                        .HasForeignKey("Pedido_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BazarTemTudo.Domain.Entities.Transportadoras", "Transportadora")
                        .WithMany()
                        .HasForeignKey("Transportadora_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedidos");

                    b.Navigation("Transportadora");
                });

            modelBuilder.Entity("BazarTemTudo.Domain.Entities.Estoque", b =>
                {
                    b.HasOne("BazarTemTudo.Domain.Entities.Produtos", "Estoque_Produto")
                        .WithMany()
                        .HasForeignKey("ProdutosID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estoque_Produto");
                });

            modelBuilder.Entity("BazarTemTudo.Domain.Entities.Fornecedores", b =>
                {
                    b.HasOne("BazarTemTudo.Domain.Entities.Endereco", "Endereco_Fornecedor")
                        .WithOne()
                        .HasForeignKey("BazarTemTudo.Domain.Entities.Fornecedores", "Endereco_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Endereco_Fornecedor");
                });

            modelBuilder.Entity("BazarTemTudo.Domain.Entities.ItensPedidos", b =>
                {
                    b.HasOne("BazarTemTudo.Domain.Entities.Pedidos", "Pedido")
                        .WithMany("ItensPedidos")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BazarTemTudo.Domain.Entities.Produtos", "Produtos")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("BazarTemTudo.Domain.Entities.NotaFiscal", b =>
                {
                    b.HasOne("BazarTemTudo.Domain.Entities.Pedidos", "Pedido")
                        .WithOne()
                        .HasForeignKey("BazarTemTudo.Domain.Entities.NotaFiscal", "PedidoID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("BazarTemTudo.Domain.Entities.Pedidos", b =>
                {
                    b.HasOne("BazarTemTudo.Domain.Entities.Clientes", "Clientes")
                        .WithMany("Pedidos")
                        .HasForeignKey("ClientesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BazarTemTudo.Domain.Entities.Endereco", "Endereco")
                        .WithOne("Pedido")
                        .HasForeignKey("BazarTemTudo.Domain.Entities.Pedidos", "Endereco_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Clientes");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("BazarTemTudo.Domain.Entities.RequisicaoCompra", b =>
                {
                    b.HasOne("BazarTemTudo.Domain.Entities.Fornecedores", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("Fornecedor_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BazarTemTudo.Domain.Entities.Produtos", "Produto")
                        .WithMany()
                        .HasForeignKey("Produto_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Fornecedor");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BazarTemTudo.Domain.Entities.Usuarios", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BazarTemTudo.Domain.Entities.Usuarios", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BazarTemTudo.Domain.Entities.Usuarios", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BazarTemTudo.Domain.Entities.Usuarios", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BazarTemTudo.Domain.Entities.Clientes", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("BazarTemTudo.Domain.Entities.Endereco", b =>
                {
                    b.Navigation("Pedido")
                        .IsRequired();
                });

            modelBuilder.Entity("BazarTemTudo.Domain.Entities.Pedidos", b =>
                {
                    b.Navigation("ItensPedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
