using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BazarTemTudo.InfraData.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DespachoMercadorias_Pedidos_PedidosId",
                table: "DespachoMercadorias");

            migrationBuilder.DropForeignKey(
                name: "FK_DespachoMercadorias_Transportadoras_TransportadoraId",
                table: "DespachoMercadorias");

            migrationBuilder.DropIndex(
                name: "IX_DespachoMercadorias_PedidosId",
                table: "DespachoMercadorias");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "DespachoMercadorias");

            migrationBuilder.DropColumn(
                name: "PedidosId",
                table: "DespachoMercadorias");

            migrationBuilder.RenameColumn(
                name: "TransportadoraId",
                table: "DespachoMercadorias",
                newName: "Pedido_Id");

            migrationBuilder.RenameIndex(
                name: "IX_DespachoMercadorias_TransportadoraId",
                table: "DespachoMercadorias",
                newName: "IX_DespachoMercadorias_Pedido_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DespachoMercadorias_Transportadora_ID",
                table: "DespachoMercadorias",
                column: "Transportadora_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_DespachoMercadorias_Pedidos_Pedido_Id",
                table: "DespachoMercadorias",
                column: "Pedido_Id",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespachoMercadorias_Transportadoras_Transportadora_ID",
                table: "DespachoMercadorias",
                column: "Transportadora_ID",
                principalTable: "Transportadoras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DespachoMercadorias_Pedidos_Pedido_Id",
                table: "DespachoMercadorias");

            migrationBuilder.DropForeignKey(
                name: "FK_DespachoMercadorias_Transportadoras_Transportadora_ID",
                table: "DespachoMercadorias");

            migrationBuilder.DropIndex(
                name: "IX_DespachoMercadorias_Transportadora_ID",
                table: "DespachoMercadorias");

            migrationBuilder.RenameColumn(
                name: "Pedido_Id",
                table: "DespachoMercadorias",
                newName: "TransportadoraId");

            migrationBuilder.RenameIndex(
                name: "IX_DespachoMercadorias_Pedido_Id",
                table: "DespachoMercadorias",
                newName: "IX_DespachoMercadorias_TransportadoraId");

            migrationBuilder.AddColumn<long>(
                name: "PedidoId",
                table: "DespachoMercadorias",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PedidosId",
                table: "DespachoMercadorias",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_DespachoMercadorias_PedidosId",
                table: "DespachoMercadorias",
                column: "PedidosId");

            migrationBuilder.AddForeignKey(
                name: "FK_DespachoMercadorias_Pedidos_PedidosId",
                table: "DespachoMercadorias",
                column: "PedidosId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DespachoMercadorias_Transportadoras_TransportadoraId",
                table: "DespachoMercadorias",
                column: "TransportadoraId",
                principalTable: "Transportadoras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
