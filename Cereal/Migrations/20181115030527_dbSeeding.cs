using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cereal.Migrations
{
    public partial class dbSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sku = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "Description", "Image", "Name", "Price", "Sku" },
                values: new object[,]
                {
                    { 1, "The original Frosted Mini-Wheats is a sweet, crunchy cereal built to help fill you up for Big Days. Crafted with ten layers of wheat and topped with frosting, they help you feel full and ready to tackle whatever the day brings.", "/assets/frosted_mini_wheats.jpg", "Frosted Mini-Wheats", 2.99m, "12345" },
                    { 2, "It’s the stuff breakfast dreams are made of! Chocolatey, crunchy O’s with that OREO® cookie taste you love and a rich creme coating combine to give you a bowlful of cookie milk that tastes so good you’ll finish it off with a smile. Dig into the cereal you’ve been missing!", "/assets/oreo_os.jpg", "Oreo O's", 2.99m, "23456" },
                    { 3, "Sweet and golden, with a crunch you can’t resist, nothing competes with the original Cap’n Crunch®. Grab a bowl or cup for an easy snack that goes great with couch time, anytime.", "/assets/capn_crunch.jpg", "Cap'n Crunch", 2.99m, "34567" },
                    { 4, "The great taste of Cookies for breakfast! A delicious cookie taste which contains whole grain & vitamins and minerals. COOKIE CRISP brings a bowlful of Cookie happiness to your day!", "/assets/cookie_crisp.jpg", "Cookie Crisp", 2.99m, "45678" },
                    { 5, "Made with real cinnamon-sparkly goodness, this cereal is so delicious you’ll want to crunch around the clock.", "/assets/cinnamon_toast_crunch.jpg", "Cinnamon Toast Crunch", 2.99m, "56789" },
                    { 6, "Life cereal is the crunchy wholesome choice that's great for Mom, Dad, and the little goofballs you can't help but love. Each tasty square is filled with whole grain goodness so you can savor the sweet moments that bring your family together.", "/assets/life.png", "Life", 2.99m, "67890" },
                    { 7, "Cocoa Puffs Chocolate Cereal First Ingredient Whole Grain. A whole grain food is made by using all three parts of the grain. All General Mills Big G cereals contain more whole grain than any other single ingredient. 12g whole grain per serving. At least 48 grams recommended daily. No colors from artificial sources and no artificial flavors.", "/assets/cocoa_puffs.jpg", "Cocoa Puffs", 2.99m, "09876" },
                    { 8, "Kid-Tested, Mother-approved.", "/assets/kix.jpg", "Kix", 2.99m, "98765" },
                    { 9, "Cheerios has been a family favorite for years. Its wholesome goodness is perfect for toddlers to adults and everyone in between. Made from whole grain oats, and without artificial flavors or colors, they’re naturally low in fat and cholesterol free. These wholesome little “o’s” have only one gram of sugar!", "/assets/cheerios.jpg", "Cheerios", 2.99m, "87654" },
                    { 10, "Golden Grahams Cereal When you crave a crunch, grab some sweet graham goodness! Now You're Golden.", "/assets/golden_grahams.jpg", "Golden Grahams", 2.99m, "76543" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
