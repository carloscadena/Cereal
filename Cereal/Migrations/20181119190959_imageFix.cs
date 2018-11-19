using Microsoft.EntityFrameworkCore.Migrations;

namespace Cereal.Migrations
{
    public partial class imageFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 3,
                column: "Image",
                value: "~/assets/capn_crunch.jpg");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 4,
                column: "Image",
                value: "~/assets/cookie_crisp.jpg");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 5,
                column: "Image",
                value: "~/assets/cinnamon_toast_crunch.jpg");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 6,
                column: "Image",
                value: "~/assets/life.png");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 7,
                column: "Image",
                value: "~/assets/cocoa_puffs.jpg");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 8,
                column: "Image",
                value: "~/assets/kix.jpg");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 9,
                column: "Image",
                value: "~/assets/cheerios.jpg");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 10,
                column: "Image",
                value: "~/assets/golden_grahams.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 3,
                column: "Image",
                value: "/assets/capn_crunch.jpg");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 4,
                column: "Image",
                value: "/assets/cookie_crisp.jpg");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 5,
                column: "Image",
                value: "/assets/cinnamon_toast_crunch.jpg");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 6,
                column: "Image",
                value: "/assets/life.png");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 7,
                column: "Image",
                value: "/assets/cocoa_puffs.jpg");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 8,
                column: "Image",
                value: "/assets/kix.jpg");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 9,
                column: "Image",
                value: "/assets/cheerios.jpg");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductID",
                keyValue: 10,
                column: "Image",
                value: "/assets/golden_grahams.jpg");
        }
    }
}
