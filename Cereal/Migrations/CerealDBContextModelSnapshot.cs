﻿// <auto-generated />
using System;
using Cereal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cereal.Migrations
{
    [DbContext(typeof(CerealDBContext))]
    partial class CerealDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cereal.Models.BasketItems", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductID");

                    b.Property<DateTime>("PurchaseDate");

                    b.Property<bool>("Purchased");

                    b.Property<int>("Quantity");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.ToTable("BasketItems");
                });

            modelBuilder.Entity("Cereal.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.Property<string>("Sku")
                        .IsRequired();

                    b.HasKey("ProductID");

                    b.ToTable("Product");

                    b.HasData(
                        new { ProductID = 1, Description = "The original Frosted Mini-Wheats is a sweet, crunchy cereal built to help fill you up for Big Days. Crafted with ten layers of wheat and topped with frosting, they help you feel full and ready to tackle whatever the day brings.", Image = "/assets/frosted_mini_wheats.jpg", Name = "Frosted Mini-Wheats", Price = 2.99m, Sku = "12345" },
                        new { ProductID = 2, Description = "It’s the stuff breakfast dreams are made of! Chocolatey, crunchy O’s with that OREO® cookie taste you love and a rich creme coating combine to give you a bowlful of cookie milk that tastes so good you’ll finish it off with a smile. Dig into the cereal you’ve been missing!", Image = "/assets/oreo_os.jpg", Name = "Oreo O's", Price = 2.99m, Sku = "23456" },
                        new { ProductID = 3, Description = "Sweet and golden, with a crunch you can’t resist, nothing competes with the original Cap’n Crunch®. Grab a bowl or cup for an easy snack that goes great with couch time, anytime.", Image = "/assets/capn_crunch.jpg", Name = "Cap'n Crunch", Price = 2.99m, Sku = "34567" },
                        new { ProductID = 4, Description = "The great taste of Cookies for breakfast! A delicious cookie taste which contains whole grain & vitamins and minerals. COOKIE CRISP brings a bowlful of Cookie happiness to your day!", Image = "/assets/cookie_crisp.jpg", Name = "Cookie Crisp", Price = 2.99m, Sku = "45678" },
                        new { ProductID = 5, Description = "Made with real cinnamon-sparkly goodness, this cereal is so delicious you’ll want to crunch around the clock.", Image = "/assets/cinnamon_toast_crunch.jpg", Name = "Cinnamon Toast Crunch", Price = 2.99m, Sku = "56789" },
                        new { ProductID = 6, Description = "Life cereal is the crunchy wholesome choice that's great for Mom, Dad, and the little goofballs you can't help but love. Each tasty square is filled with whole grain goodness so you can savor the sweet moments that bring your family together.", Image = "/assets/life.png", Name = "Life", Price = 2.99m, Sku = "67890" },
                        new { ProductID = 7, Description = "Cocoa Puffs Chocolate Cereal First Ingredient Whole Grain. A whole grain food is made by using all three parts of the grain. All General Mills Big G cereals contain more whole grain than any other single ingredient. 12g whole grain per serving. At least 48 grams recommended daily. No colors from artificial sources and no artificial flavors.", Image = "/assets/cocoa_puffs.jpg", Name = "Cocoa Puffs", Price = 2.99m, Sku = "09876" },
                        new { ProductID = 8, Description = "Kid-Tested, Mother-approved.", Image = "/assets/kix.jpg", Name = "Kix", Price = 2.99m, Sku = "98765" },
                        new { ProductID = 9, Description = "Cheerios has been a family favorite for years. Its wholesome goodness is perfect for toddlers to adults and everyone in between. Made from whole grain oats, and without artificial flavors or colors, they’re naturally low in fat and cholesterol free. These wholesome little “o’s” have only one gram of sugar!", Image = "/assets/cheerios.jpg", Name = "Cheerios", Price = 2.99m, Sku = "87654" },
                        new { ProductID = 10, Description = "Golden Grahams Cereal When you crave a crunch, grab some sweet graham goodness! Now You're Golden.", Image = "/assets/golden_grahams.jpg", Name = "Golden Grahams", Price = 2.99m, Sku = "76543" }
                    );
                });

            modelBuilder.Entity("Cereal.Models.BasketItems", b =>
                {
                    b.HasOne("Cereal.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
