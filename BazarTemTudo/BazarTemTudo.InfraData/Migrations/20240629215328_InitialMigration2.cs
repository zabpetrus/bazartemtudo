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
                name: "FK_Produtos_ItensPedidos_itensPedidosId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_itensPedidosId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "itensPedidosId",
                table: "Produtos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "itensPedidosId",
                table: "Produtos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_itensPedidosId",
                table: "Produtos",
                column: "itensPedidosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_ItensPedidos_itensPedidosId",
                table: "Produtos",
                column: "itensPedidosId",
                principalTable: "ItensPedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
