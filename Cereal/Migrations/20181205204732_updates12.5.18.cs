using Microsoft.EntityFrameworkCore.Migrations;

namespace Cereal.Migrations
{
    public partial class updates12518 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "BasketItems",
                newName: "PurchaseDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PurchaseDate",
                table: "BasketItems",
                newName: "Date");
        }
    }
}
