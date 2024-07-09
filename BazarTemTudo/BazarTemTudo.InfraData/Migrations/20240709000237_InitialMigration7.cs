using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BazarTemTudo.InfraData.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkout_Pedidos_PedidoId",
                table: "Checkout");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Enderecos");

            migrationBuilder.RenameColumn(
                name: "PedidoId",
                table: "Checkout",
                newName: "Pedido_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Checkout_PedidoId",
                table: "Checkout",
                newName: "IX_Checkout_Pedido_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkout_Pedidos_Pedido_Id",
                table: "Checkout",
                column: "Pedido_Id",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkout_Pedidos_Pedido_Id",
                table: "Checkout");

            migrationBuilder.RenameColumn(
                name: "Pedido_Id",
                table: "Checkout",
                newName: "PedidoId");

            migrationBuilder.RenameIndex(
                name: "IX_Checkout_Pedido_Id",
                table: "Checkout",
                newName: "IX_Checkout_PedidoId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Enderecos",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkout_Pedidos_PedidoId",
                table: "Checkout",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
