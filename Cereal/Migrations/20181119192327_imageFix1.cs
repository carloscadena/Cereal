using Microsoft.EntityFrameworkCore.Migrations;

namespace Cereal.Migrations
{
    public partial class imageFix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 1,
                column: "Image",
                value: "/assets/frosted_mini_wheats.jpg");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 2,
                column: "Image",
                value: "/assets/oreo_os.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 1,
                column: "Image",
                value: "~/assets/frosted_mini_wheats.jpg");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 2,
                column: "Image",
                value: "~/assets/oreo_os.jpg");
        }
    }
}
