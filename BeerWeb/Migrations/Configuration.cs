namespace BeerWeb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BeerWeb.Models.BeerModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BeerWeb.Models.BeerModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Categories.AddOrUpdate(c => c.Id,
                new Models.Category { Id= 1, Name = "Lager" },
                new Models.Category { Id = 2, Name = "Ale" },
                new Models.Category { Id = 3, Name = "IPA" });

            context.Products.AddOrUpdate(p => p.Id,
                new Models.Product { Id = 1, Name = "Guldkällan", Description = "Soft and light beer." , Price = 10, Category_Id = 1, PicURL = "https://static.systembolaget.se/imagelibrary/publishedmedia/1czb16mapfxgw3mk3tgy/508185.jpg", DeliveryTime = "5 Days", UnitsInStock = 199 },
                new Models.Product { Id = 2, Name = "Peroni", Description = "Italian lager great with meat.", Price = 15, Category_Id = 1, PicURL = "https://static.systembolaget.se/imagelibrary/publishedmedia/3s46njh9likqm99vh473/1155844.jpg", DeliveryTime = "9 Days", UnitsInStock = 128 },
                new Models.Product { Id = 3, Name = "Newcastle", Description = "Brown ale from Newcastle", Price = 20, Category_Id = 2, PicURL = "https://static.systembolaget.se/imagelibrary/publishedmedia/pcdgmnegrsmdhf0d6zmz/1134.jpg", DeliveryTime = "8 Days", UnitsInStock = 580 },
                new Models.Product { Id = 4, Name = "Big kahuna", Description = "Perfectly brewed ale from Hawaii", Price = 25, Category_Id = 2, PicURL = "https://static.systembolaget.se/imagelibrary/publishedmedia/fkvp4ghhfhtyauusz5fj/15478974.jpg", DeliveryTime = "3 Days", UnitsInStock = 99 },
                new Models.Product { Id = 5, Name = "Wisby IPA", Description = "Swedens most upvoted IPA", Price = 30, Category_Id = 3, PicURL = "https://static.systembolaget.se/imagelibrary/publishedmedia/67zhwmxg8r21hghcdx4k/402935.jpg", DeliveryTime = "3 Days", UnitsInStock = 9 },
                new Models.Product { Id = 6, Name = "A ship full of IPA", Description = "Unknown.", Price = 11, Category_Id = 3, PicURL = "https://static.systembolaget.se/imagelibrary/publishedmedia/cid16w92xltzsrm7m0zr/931037.jpg", DeliveryTime = "1 Days", UnitsInStock = 899 });
        }
    }
}
