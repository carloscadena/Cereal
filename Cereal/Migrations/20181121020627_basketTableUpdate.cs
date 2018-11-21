using Microsoft.EntityFrameworkCore.Migrations;

namespace Cereal.Migrations
{
    public partial class basketTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasketID",
                table: "BasketItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BasketID",
                table: "BasketItems",
                nullable: false,
                defaultValue: 0);
        }
    }
}
