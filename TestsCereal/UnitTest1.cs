using Cereal.Data;
using Cereal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using System.Linq;

namespace TestsCereal
{
    public class UnitTest1
    {
        /// <summary>
        /// Test to get a product sku
        /// </summary>
        [Fact]
        public void GetSku()
        {
            Product product = new Product();
            product.Sku = "12345";

            Assert.Equal("12345", product.Sku);
        }

        /// <summary>
        /// Test to set a product sku
        /// </summary>
        [Fact]
        public void SetSku()
        {
            Product product = new Product();
            product.Sku = "12345";

            product.Sku = "44444";

            Assert.Equal("44444", product.Sku);
        }

        /// <summary>
        /// Test to get a product name
        /// </summary>
        [Fact]
        public void GetName()
        {
            Product product = new Product();
            product.Name = "Cereal";

            Assert.Equal("Cereal", product.Name);
        }

        /// <summary>
        /// Test to set a product name
        /// </summary>
        [Fact]
        public void SetName()
        {
            Product product = new Product();
            product.Name = "Cereal";

            product.Name = "Life";

            Assert.Equal("Life", product.Name);
        }

        /// <summary>
        /// Test to get a product price
        /// </summary>
        [Fact]
        public void GetPrice()
        {
            Product product = new Product();
            product.Price = 4.99M;

            Assert.Equal(4.99M, product.Price);
        }

        /// <summary>
        /// Test to set a product price
        /// </summary>
        [Fact]
        public void SetPrice()
        {
            Product product = new Product();
            product.Price = 4.99M;

            product.Price = 2.99M;

            Assert.Equal(2.99M, product.Price);
        }

        /// <summary>
        /// Test to get a product description
        /// </summary>
        [Fact]
        public void GetDescription()
        {
            Product product = new Product();
            product.Description = "Cereal is good";

            Assert.Equal("Cereal is good", product.Description);
        }

        /// <summary>
        /// Test to set a product description
        /// </summary>
        [Fact]
        public void SetDescription()
        {
            Product product = new Product();
            product.Description = "Cereal is good";

            product.Description = "Good is cereal";

            Assert.Equal("Good is cereal", product.Description);
        }

        ///// <summary>
        ///// Test to get a application user first name
        ///// </summary>
        //[Fact]
        //public void GetUserFirstName()
        //{
        //    ApplicationUser user = new ApplicationUser();
        //    user.FirstName = "allisa";

        //    Assert.Equal("allisa", user.FirstName);
        //}

        ///// <summary>
        ///// Test to set a application user first name
        ///// </summary>
        //[Fact]
        //public void SetUserFirstName()
        //{
        //    ApplicationUser user = new ApplicationUser();
        //    user.FirstName = "allisa";

        //    user.FirstName = "carlos";

        //    Assert.Equal("carlos", user.FirstName);
        //}

        ///// <summary>
        ///// Test to get a application user last name
        ///// </summary>
        //[Fact]
        //public void GetUserLastName()
        //{
        //    ApplicationUser user = new ApplicationUser();
        //    user.LastName = "lebeuf";

        //    Assert.Equal("lebeuf", user.LastName);
        //}

        ///// <summary>
        ///// Test to set a application user last name
        ///// </summary>
        //[Fact]
        //public void SetUserName()
        //{
        //    ApplicationUser user = new ApplicationUser();
        //    user.LastName = "lebeuf";

        //    user.LastName = "cadena";

        //    Assert.Equal("cadena", user.LastName);
        //}


        [Fact]
        public async void CreateBasketItemTest()
        {
            DbContextOptions<CerealDBContext> options =
                new DbContextOptionsBuilder<CerealDBContext>()
                .UseInMemoryDatabase("Baskets")
                .Options;

            using (CerealDBContext context = new CerealDBContext(options))
            {
                //CREATE
                BasketItems basket = new BasketItems();
                basket.ID = 1;
                basket.ProductID = 2;
                basket.Quantity = 2;
                basket.UserID = "userid";
                basket.Purchased = false;

                context.BasketItems.Add(basket);

                await context.SaveChangesAsync();
           
                Assert.Equal(1, basket.ID);

            }
        }

        [Fact]
        public async void ReadBasketItemTest()
        {
            DbContextOptions<CerealDBContext> options =
                new DbContextOptionsBuilder<CerealDBContext>()
                .UseInMemoryDatabase("Baskets")
                .Options;

            using (CerealDBContext context = new CerealDBContext(options))
            {
                //CREATE
                BasketItems basket = new BasketItems();
                basket.ID = 2;
                basket.ProductID = 2;
                basket.Quantity = 2;
                basket.UserID = "userid";
                basket.Purchased = false;

                context.BasketItems.Add(basket);

                await context.SaveChangesAsync();

                //READ
                var myBasket = await context.BasketItems.FirstOrDefaultAsync(r => r.ID == basket.ID);

                Assert.Equal(2, myBasket.ID);
            }
        }

        [Fact]
        public async void UpdateBasketItemTest()
        {
            DbContextOptions<CerealDBContext> options =
                new DbContextOptionsBuilder<CerealDBContext>()
                .UseInMemoryDatabase("Baskets")
                .Options;

            using (CerealDBContext context = new CerealDBContext(options))
            {
                //CREATE
                BasketItems basket = new BasketItems();
                basket.ID = 3;
                basket.ProductID = 2;
                basket.Quantity = 2;
                basket.UserID = "userid";
                basket.Purchased = false;

                context.BasketItems.Add(basket);

                await context.SaveChangesAsync();

                //READ
                var myBasket = await context.BasketItems.FirstOrDefaultAsync(r => r.ID == basket.ID);

                //UPDATE
                myBasket.Quantity = 4;
                context.Update(myBasket);
                context.SaveChanges();

                var newBasket = await context.BasketItems.FirstOrDefaultAsync(r => r.ID == myBasket.ID);
                Assert.Equal(4, newBasket.Quantity);
            }
        }

        [Fact]
        public async void DeleteBasketItemTest()
        {
            DbContextOptions<CerealDBContext> options =
                new DbContextOptionsBuilder<CerealDBContext>()
                .UseInMemoryDatabase("Baskets")
                .Options;

            using (CerealDBContext context = new CerealDBContext(options))
            {
                //CREATE
                BasketItems basket = new BasketItems();
                basket.ID = 4;
                basket.ProductID = 2;
                basket.Quantity = 2;
                basket.UserID = "userid";
                basket.Purchased = false;

                context.BasketItems.Add(basket);

                await context.SaveChangesAsync();

                //READ
                var myBasket = await context.BasketItems.FirstOrDefaultAsync(r => r.ID == basket.ID);

                //DELETE
                context.BasketItems.Remove(myBasket);
                context.SaveChanges();

                var deletedBasketItems = await context.BasketItems.FirstOrDefaultAsync(r => r.ID == myBasket.ID);
                Assert.True(deletedBasketItems == null);
            }
        }
    }
}
