namespace ExtendedQuery.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<ExtendedQuery.Data.QueryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ExtendedQuery.Data.QueryContext";
        }

        protected override void Seed(ExtendedQuery.Data.QueryContext context)
        {
            var client = new Client
            {
                Name = "Vasi Vasilev",
                Age = 30,
                Orders = new HashSet<Order>
                    {
                        
                    }
            };

            var order = new Order
            {
                Products = new HashSet<Product>()
                            {
                                product
                            }
            };

            var product = new Product
            {
                Name = "Oil pump"
            };

            context.Clients.AddOrUpdate(c => c.Name,
                new Client
                {
                    Name = "Peter Ivanov",
                    Address = "Tintyava 15-17",
                    Age = 18
                }, new Client
                {
                    Name = "Ivan Pertov",
                    Address = "Pozitano 5",
                    Age = 25
                }, , new Client
                {
                    Name = "Anton Angelov",
                    Age = 21
                });
            context.Products.AddOrUpdate(p => p.Name, product);

            context.SaveChanges();
        }
    }
}
