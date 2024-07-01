using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BazarTemTudo.InfraData.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkout_Pedidos_Pedido_ClienteId",
                table: "Checkout");

            migrationBuilder.DropIndex(
                name: "IX_Checkout_Pedido_ClienteId",
                table: "Checkout");

            migrationBuilder.DropColumn(
                name: "Pedidos_ID",
                table: "NotaFiscal");

            migrationBuilder.DropColumn(
                name: "Pedido_Id",
                table: "Checkout");

            migrationBuilder.RenameColumn(
                name: "Pedido_ClienteId",
                table: "Checkout",
                newName: "PedidoId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total_Compra",
                table: "RequisicaoCompra",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PedidoID",
                table: "NotaFiscal",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscal_PedidoID",
                table: "NotaFiscal",
                column: "PedidoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Checkout_PedidoId",
                table: "Checkout",
                column: "PedidoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkout_Pedidos_PedidoId",
                table: "Checkout",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFiscal_Pedidos_PedidoID",
                table: "NotaFiscal",
                column: "PedidoID",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkout_Pedidos_PedidoId",
                table: "Checkout");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaFiscal_Pedidos_PedidoID",
                table: "NotaFiscal");

            migrationBuilder.DropIndex(
                name: "IX_NotaFiscal_PedidoID",
                table: "NotaFiscal");

            migrationBuilder.DropIndex(
                name: "IX_Checkout_PedidoId",
                table: "Checkout");

            migrationBuilder.DropColumn(
                name: "PedidoID",
                table: "NotaFiscal");

            migrationBuilder.RenameColumn(
                name: "PedidoId",
                table: "Checkout",
                newName: "Pedido_ClienteId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total_Compra",
                table: "RequisicaoCompra",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "Pedidos_ID",
                table: "NotaFiscal",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Pedido_Id",
                table: "Checkout",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Checkout_Pedido_ClienteId",
                table: "Checkout",
                column: "Pedido_ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkout_Pedidos_Pedido_ClienteId",
                table: "Checkout",
                column: "Pedido_ClienteId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
