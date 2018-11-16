using Cereal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cereal.Data
{
    public class CerealDBContext : DbContext
    {
        public CerealDBContext(DbContextOptions<CerealDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => new { p.ProductID });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductID = 1,
                    Name = "Frosted Mini-Wheats",
                    Sku = "12345",
                    Price = 2.99M,
                    Description = "The original Frosted Mini-Wheats is a sweet, crunchy cereal built to help fill you up for Big Days. Crafted with ten layers of wheat and topped with frosting, they help you feel full and ready to tackle whatever the day brings.",
                    Image = "~/assets/frosted_mini_wheats.jpg"
                },
                new Product
                {
                    ProductID = 2,
                    Name = "Oreo O's",
                    Sku = "23456",
                    Price = 2.99M,
                    Description = "It’s the stuff breakfast dreams are made of! Chocolatey, crunchy O’s with that OREO® cookie taste you love and a rich creme coating combine to give you a bowlful of cookie milk that tastes so good you’ll finish it off with a smile. Dig into the cereal you’ve been missing!",
                    Image = "~/assets/oreo_os.jpg"
                },
                new Product
                {
                    ProductID = 3,
                    Name = "Cap'n Crunch",
                    Sku = "34567",
                    Price = 2.99M,
                    Description = "Sweet and golden, with a crunch you can’t resist, nothing competes with the original Cap’n Crunch®. Grab a bowl or cup for an easy snack that goes great with couch time, anytime.",
                    Image = "~/assets/capn_crunch.jpg"
                },
                new Product
                {
                    ProductID = 4,
                    Name = "Cookie Crisp",
                    Sku = "45678",
                    Price = 2.99M,
                    Description = "The great taste of Cookies for breakfast! A delicious cookie taste which contains whole grain & vitamins and minerals. COOKIE CRISP brings a bowlful of Cookie happiness to your day!",
                    Image = "~/assets/cookie_crisp.jpg"
                },
                new Product
                {
                    ProductID = 5,
                    Name = "Cinnamon Toast Crunch",
                    Sku = "56789",
                    Price = 2.99M,
                    Description = "Made with real cinnamon-sparkly goodness, this cereal is so delicious you’ll want to crunch around the clock.",
                    Image = "~/assets/cinnamon_toast_crunch.jpg"
                },
                new Product
                {
                    ProductID = 6,
                    Name = "Life",
                    Sku = "67890",
                    Price = 2.99M,
                    Description = "Life cereal is the crunchy wholesome choice that's great for Mom, Dad, and the little goofballs you can't help but love. Each tasty square is filled with whole grain goodness so you can savor the sweet moments that bring your family together.",
                    Image = "~/assets/life.png"
                },
                new Product
                {
                    ProductID = 7,
                    Name = "Cocoa Puffs",
                    Sku = "09876",
                    Price = 2.99M,
                    Description = "Cocoa Puffs Chocolate Cereal First Ingredient Whole Grain. A whole grain food is made by using all three parts of the grain. All General Mills Big G cereals contain more whole grain than any other single ingredient. 12g whole grain per serving. At least 48 grams recommended daily. No colors from artificial sources and no artificial flavors.",
                    Image = "~/assets/cocoa_puffs.jpg"
                },
                new Product
                {
                    ProductID = 8,
                    Name = "Kix",
                    Sku = "98765",
                    Price = 2.99M,
                    Description = "Kid-Tested, Mother-approved.",
                    Image = "~/assets/kix.jpg"
                },
                new Product
                {
                    ProductID = 9,
                    Name = "Cheerios",
                    Sku = "87654",
                    Price = 2.99M,
                    Description = "Cheerios has been a family favorite for years. Its wholesome goodness is perfect for toddlers to adults and everyone in between. Made from whole grain oats, and without artificial flavors or colors, they’re naturally low in fat and cholesterol free. These wholesome little “o’s” have only one gram of sugar!",
                    Image = "~/assets/cheerios.jpg"
                },
                new Product
                {
                    ProductID = 10,
                    Name = "Golden Grahams",
                    Sku = "76543",
                    Price = 2.99M,
                    Description = "Golden Grahams Cereal When you crave a crunch, grab some sweet graham goodness! Now You're Golden.",
                    Image = "~/assets/golden_grahams.jpg"
                }
                );
        }
        public DbSet<Product> Product { get; set; }
    }
}
