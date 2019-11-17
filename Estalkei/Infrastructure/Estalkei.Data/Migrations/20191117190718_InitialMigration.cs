using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Estalkei.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExchangeType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ExchangeType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Compra" });

            migrationBuilder.InsertData(
                table: "ExchangeType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Venda" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangeType");
        }
    }
}
