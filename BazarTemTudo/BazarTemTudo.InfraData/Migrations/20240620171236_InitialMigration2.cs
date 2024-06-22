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
            migrationBuilder.RenameColumn(
                name: "Upc",
                table: "Carga",
                newName: "upc");

            migrationBuilder.RenameColumn(
                name: "Sku",
                table: "Carga",
                newName: "sku");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Carga",
                newName: "cpf");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Carga",
                newName: "ship_state");

            migrationBuilder.RenameColumn(
                name: "Uf",
                table: "Carga",
                newName: "ship_service_level");

            migrationBuilder.RenameColumn(
                name: "Qte",
                table: "Carga",
                newName: "quantity_purchased");

            migrationBuilder.RenameColumn(
                name: "Pais",
                table: "Carga",
                newName: "ship_postal_code");

            migrationBuilder.RenameColumn(
                name: "NomeProduto",
                table: "Carga",
                newName: "ship_country");

            migrationBuilder.RenameColumn(
                name: "NomeComprador",
                table: "Carga",
                newName: "ship_city");

            migrationBuilder.RenameColumn(
                name: "Frete",
                table: "Carga",
                newName: "ship_address_3");

            migrationBuilder.RenameColumn(
                name: "FornecedorCnpj",
                table: "Carga",
                newName: "ship_address_2");

            migrationBuilder.RenameColumn(
                name: "Fornecedor",
                table: "Carga",
                newName: "ship_address_1");

            migrationBuilder.RenameColumn(
                name: "EnderecoEntrega",
                table: "Carga",
                newName: "purchase_date");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Carga",
                newName: "product_name");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Carga",
                newName: "payments_date");

            migrationBuilder.RenameColumn(
                name: "DataPedido",
                table: "Carga",
                newName: "order_item_id");

            migrationBuilder.RenameColumn(
                name: "CodigoPedido",
                table: "Carga",
                newName: "item_price");

            migrationBuilder.RenameColumn(
                name: "Cep",
                table: "Carga",
                newName: "currency");

            migrationBuilder.AddColumn<string>(
                name: "buyer_email",
                table: "Carga",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "buyer_name",
                table: "Carga",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "buyer_phone_number",
                table: "Carga",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "order_id",
                table: "Carga",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "buyer_email",
                table: "Carga");

            migrationBuilder.DropColumn(
                name: "buyer_name",
                table: "Carga");

            migrationBuilder.DropColumn(
                name: "buyer_phone_number",
                table: "Carga");

            migrationBuilder.DropColumn(
                name: "order_id",
                table: "Carga");

            migrationBuilder.RenameColumn(
                name: "upc",
                table: "Carga",
                newName: "Upc");

            migrationBuilder.RenameColumn(
                name: "sku",
                table: "Carga",
                newName: "Sku");

            migrationBuilder.RenameColumn(
                name: "cpf",
                table: "Carga",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "ship_state",
                table: "Carga",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "ship_service_level",
                table: "Carga",
                newName: "Uf");

            migrationBuilder.RenameColumn(
                name: "ship_postal_code",
                table: "Carga",
                newName: "Pais");

            migrationBuilder.RenameColumn(
                name: "ship_country",
                table: "Carga",
                newName: "NomeProduto");

            migrationBuilder.RenameColumn(
                name: "ship_city",
                table: "Carga",
                newName: "NomeComprador");

            migrationBuilder.RenameColumn(
                name: "ship_address_3",
                table: "Carga",
                newName: "Frete");

            migrationBuilder.RenameColumn(
                name: "ship_address_2",
                table: "Carga",
                newName: "FornecedorCnpj");

            migrationBuilder.RenameColumn(
                name: "ship_address_1",
                table: "Carga",
                newName: "Fornecedor");

            migrationBuilder.RenameColumn(
                name: "quantity_purchased",
                table: "Carga",
                newName: "Qte");

            migrationBuilder.RenameColumn(
                name: "purchase_date",
                table: "Carga",
                newName: "EnderecoEntrega");

            migrationBuilder.RenameColumn(
                name: "product_name",
                table: "Carga",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "payments_date",
                table: "Carga",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "order_item_id",
                table: "Carga",
                newName: "DataPedido");

            migrationBuilder.RenameColumn(
                name: "item_price",
                table: "Carga",
                newName: "CodigoPedido");

            migrationBuilder.RenameColumn(
                name: "currency",
                table: "Carga",
                newName: "Cep");
        }
    }
}
