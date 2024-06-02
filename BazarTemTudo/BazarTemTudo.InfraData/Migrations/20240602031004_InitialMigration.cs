using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BazarTemTudo.InfraData.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    CPF = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Data_Registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Data_Atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Rua = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Complemento1 = table.Column<string>(type: "text", nullable: false),
                    Complemento2 = table.Column<string>(type: "text", nullable: false),
                    Cep = table.Column<string>(type: "text", nullable: false),
                    Cidade = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    Pais = table.Column<string>(type: "text", nullable: false),
                    Data_Registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Data_Atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Key = table.Column<string>(type: "text", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Transportadoras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NomeTransportadora = table.Column<string>(type: "text", nullable: false),
                    CNPJ = table.Column<string>(type: "text", nullable: false),
                    TipoServico = table.Column<int>(type: "integer", nullable: false),
                    CustoFrete = table.Column<decimal>(type: "numeric", nullable: false),
                    Data_Registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Data_Atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportadoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome_Fornecedor = table.Column<string>(type: "text", nullable: false),
                    CNPJ = table.Column<string>(type: "text", nullable: false),
                    Endereco_ID = table.Column<int>(type: "integer", nullable: false),
                    Endereco_FornecedorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Website = table.Column<string>(type: "text", nullable: false),
                    Data_Registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Data_Atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fornecedores_Enderecos_Endereco_FornecedorId",
                        column: x => x.Endereco_FornecedorId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Codigo_Pedido = table.Column<string>(type: "text", nullable: false),
                    Clientes_IdId = table.Column<Guid>(type: "uuid", nullable: false),
                    Data_Pedido = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Endereco_EntregaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status_Pedido = table.Column<int>(type: "integer", nullable: false),
                    Data_Registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Data_Atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_Clientes_IdId",
                        column: x => x.Clientes_IdId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Enderecos_Endereco_EntregaId",
                        column: x => x.Endereco_EntregaId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    CPF = table.Column<string>(type: "text", nullable: false),
                    Endereco_ID = table.Column<int>(type: "integer", nullable: false),
                    Endereco_UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    Data_Registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Data_Atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Enderecos_Endereco_UsuarioId",
                        column: x => x.Endereco_UsuarioId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DespachoMercadorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Transportadora_ID = table.Column<int>(type: "integer", nullable: false),
                    TransportadoraId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status_Entrega = table.Column<int>(type: "integer", nullable: false),
                    Data_Liberacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Data_Registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Data_Atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DespachoMercadorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DespachoMercadorias_Transportadoras_TransportadoraId",
                        column: x => x.TransportadoraId,
                        principalTable: "Transportadoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome_Produto = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    SKU = table.Column<string>(type: "text", nullable: false),
                    UPC = table.Column<string>(type: "text", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    Frete_Produto = table.Column<decimal>(type: "numeric", nullable: false),
                    Fornecedor_ID = table.Column<int>(type: "integer", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Data_Registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Data_Atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Checkout",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Pedido_Id = table.Column<int>(type: "integer", nullable: false),
                    Pedido_ClienteId = table.Column<Guid>(type: "uuid", nullable: false),
                    Total_Pedido = table.Column<decimal>(type: "numeric", nullable: false),
                    Status_Despacho = table.Column<int>(type: "integer", nullable: false),
                    DataDespacho = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Data_Registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Data_Atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkout_Pedidos_Pedido_ClienteId",
                        column: x => x.Pedido_ClienteId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Pedidos_ID = table.Column<int>(type: "integer", nullable: false),
                    pedido_ClienteId = table.Column<Guid>(type: "uuid", nullable: false),
                    Valor_Total = table.Column<decimal>(type: "numeric", nullable: false),
                    Data_Emissao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Data_Registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Data_Atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotaFiscal_Pedidos_pedido_ClienteId",
                        column: x => x.pedido_ClienteId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerfilUsuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Perfil_Usuario_ID = table.Column<int>(type: "integer", nullable: false),
                    usuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    CPF = table.Column<string>(type: "text", nullable: false),
                    Data_Registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Data_Atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerfilUsuario_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Produtos_ID = table.Column<int>(type: "integer", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    Estoque_Minimo = table.Column<int>(type: "integer", nullable: false),
                    Data_Registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Data_Atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estoque_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensPedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Pedidos_ID = table.Column<int>(type: "integer", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Produtos_ID = table.Column<int>(type: "integer", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    Preco = table.Column<decimal>(type: "numeric", nullable: false),
                    disponivel_estoque = table.Column<bool>(type: "boolean", nullable: false),
                    Data_Registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Data_Atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensPedidos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensPedidos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisicaoCompra",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Fornecedor_ID = table.Column<int>(type: "integer", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Produto_ID = table.Column<int>(type: "integer", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    Status_Pedido = table.Column<int>(type: "integer", nullable: false),
                    Total_Compra = table.Column<decimal>(type: "numeric", nullable: true),
                    Data_Emissao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Data_Registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Data_Atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisicaoCompra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequisicaoCompra_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequisicaoCompra_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checkout_Pedido_ClienteId",
                table: "Checkout",
                column: "Pedido_ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_DespachoMercadorias_TransportadoraId",
                table: "DespachoMercadorias",
                column: "TransportadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_ProdutoId",
                table: "Estoque",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_Endereco_FornecedorId",
                table: "Fornecedores",
                column: "Endereco_FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_PedidoId",
                table: "ItensPedidos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_ProdutoId",
                table: "ItensPedidos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscal_pedido_ClienteId",
                table: "NotaFiscal",
                column: "pedido_ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_Clientes_IdId",
                table: "Pedidos",
                column: "Clientes_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_Endereco_EntregaId",
                table: "Pedidos",
                column: "Endereco_EntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUsuario_usuarioId",
                table: "PerfilUsuario",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FornecedorId",
                table: "Produtos",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisicaoCompra_FornecedorId",
                table: "RequisicaoCompra",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisicaoCompra_ProdutoId",
                table: "RequisicaoCompra",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Endereco_UsuarioId",
                table: "Usuarios",
                column: "Endereco_UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checkout");

            migrationBuilder.DropTable(
                name: "DespachoMercadorias");

            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropTable(
                name: "ItensPedidos");

            migrationBuilder.DropTable(
                name: "NotaFiscal");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "PerfilUsuario");

            migrationBuilder.DropTable(
                name: "RequisicaoCompra");

            migrationBuilder.DropTable(
                name: "Transportadoras");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
