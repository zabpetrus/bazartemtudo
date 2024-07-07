using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BazarTemTudo.InfraData.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Enderecos_Endereco_ID",
                table: "Fornecedores");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedores_Endereco_ID",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "Endereco_ID",
                table: "Fornecedores");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Enderecos",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Enderecos");

            migrationBuilder.AddColumn<long>(
                name: "Endereco_ID",
                table: "Fornecedores",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_Endereco_ID",
                table: "Fornecedores",
                column: "Endereco_ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Enderecos_Endereco_ID",
                table: "Fornecedores",
                column: "Endereco_ID",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
