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
                name: "FK_DespachoMercadorias_Pedidos_PedidoId",
                table: "DespachoMercadorias");

            migrationBuilder.DropForeignKey(
                name: "FK_DespachoMercadorias_Transportadoras_Transportadora_ID",
                table: "DespachoMercadorias");

            migrationBuilder.DropIndex(
                name: "IX_DespachoMercadorias_PedidoId",
                table: "DespachoMercadorias");

            migrationBuilder.DropIndex(
                name: "IX_DespachoMercadorias_Transportadora_ID",
                table: "DespachoMercadorias");

            migrationBuilder.AddColumn<long>(
                name: "PedidosId",
                table: "DespachoMercadorias",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TransportadoraId",
                table: "DespachoMercadorias",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_DespachoMercadorias_PedidosId",
                table: "DespachoMercadorias",
                column: "PedidosId");

            migrationBuilder.CreateIndex(
                name: "IX_DespachoMercadorias_TransportadoraId",
                table: "DespachoMercadorias",
                column: "TransportadoraId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_DespachoMercadorias_TransportadoraId",
                table: "DespachoMercadorias");

            migrationBuilder.DropColumn(
                name: "PedidosId",
                table: "DespachoMercadorias");

            migrationBuilder.DropColumn(
                name: "TransportadoraId",
                table: "DespachoMercadorias");

            migrationBuilder.CreateIndex(
                name: "IX_DespachoMercadorias_PedidoId",
                table: "DespachoMercadorias",
                column: "PedidoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DespachoMercadorias_Transportadora_ID",
                table: "DespachoMercadorias",
                column: "Transportadora_ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DespachoMercadorias_Pedidos_PedidoId",
                table: "DespachoMercadorias",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DespachoMercadorias_Transportadoras_Transportadora_ID",
                table: "DespachoMercadorias",
                column: "Transportadora_ID",
                principalTable: "Transportadoras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
