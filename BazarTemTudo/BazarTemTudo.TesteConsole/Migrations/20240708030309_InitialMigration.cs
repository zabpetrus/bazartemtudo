using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BazarTemTudo.TesteConsole.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    order_item_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    purchase_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    payments_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    buyer_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    buyer_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    buyer_phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    upc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity_purchased = table.Column<int>(type: "int", nullable: false),
                    currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    item_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ship_service_level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ship_address_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ship_address_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ship_address_3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ship_city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ship_state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ship_postal_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ship_country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carga", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carga");
        }
    }
}
