using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BazarTemTudo.InfraData.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequisicaoCompra_Fornecedores_FornecedorId",
                table: "RequisicaoCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_RequisicaoCompra_Produtos_ProdutoId",
                table: "RequisicaoCompra");

            migrationBuilder.DropIndex(
                name: "IX_RequisicaoCompra_FornecedorId",
                table: "RequisicaoCompra");

            migrationBuilder.DropIndex(
                name: "IX_RequisicaoCompra_ProdutoId",
                table: "RequisicaoCompra");

            migrationBuilder.DropColumn(
                name: "FornecedorId",
                table: "RequisicaoCompra");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "RequisicaoCompra");

            migrationBuilder.AlterColumn<long>(
                name: "Produto_ID",
                table: "RequisicaoCompra",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "Fornecedor_ID",
                table: "RequisicaoCompra",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_RequisicaoCompra_Fornecedor_ID",
                table: "RequisicaoCompra",
                column: "Fornecedor_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RequisicaoCompra_Produto_ID",
                table: "RequisicaoCompra",
                column: "Produto_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_RequisicaoCompra_Fornecedores_Fornecedor_ID",
                table: "RequisicaoCompra",
                column: "Fornecedor_ID",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequisicaoCompra_Produtos_Produto_ID",
                table: "RequisicaoCompra",
                column: "Produto_ID",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequisicaoCompra_Fornecedores_Fornecedor_ID",
                table: "RequisicaoCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_RequisicaoCompra_Produtos_Produto_ID",
                table: "RequisicaoCompra");

            migrationBuilder.DropIndex(
                name: "IX_RequisicaoCompra_Fornecedor_ID",
                table: "RequisicaoCompra");

            migrationBuilder.DropIndex(
                name: "IX_RequisicaoCompra_Produto_ID",
                table: "RequisicaoCompra");

            migrationBuilder.AlterColumn<int>(
                name: "Produto_ID",
                table: "RequisicaoCompra",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Fornecedor_ID",
                table: "RequisicaoCompra",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "FornecedorId",
                table: "RequisicaoCompra",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ProdutoId",
                table: "RequisicaoCompra",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_RequisicaoCompra_FornecedorId",
                table: "RequisicaoCompra",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisicaoCompra_ProdutoId",
                table: "RequisicaoCompra",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequisicaoCompra_Fornecedores_FornecedorId",
                table: "RequisicaoCompra",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequisicaoCompra_Produtos_ProdutoId",
                table: "RequisicaoCompra",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
