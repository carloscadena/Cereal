using Microsoft.EntityFrameworkCore.Migrations;

namespace Cereal.Migrations
{
    public partial class toProduction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 5,
                column: "Image",
                value: "~/assets/cinnamon_toast_crunch.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 5,
                column: "Image",
                value: "/assets/cinnamon_toast_crunch.jpg");
        }
    }
}
