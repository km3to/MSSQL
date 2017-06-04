namespace Migrations
{
    using System;
    using System.Data.Entity;

    public class InitializeAndSeed : CreateDatabaseIfNotExists<SalesContext>
    {
        protected override void Seed(SalesContext context)
        {
            //Add locations
            var sofia = new StoreLocation()
            {
                LocationName = "Sofia"
            };
            var plovdiv = new StoreLocation()
            {
                LocationName = "Plovdiv"
            };
            var varna = new StoreLocation()
            {
                LocationName = "Varna"
            };

            context.StoreLocations.Add(sofia);
            context.StoreLocations.Add(plovdiv);
            context.StoreLocations.Add(varna);

            //Add products
            var car = new Product()
            {
                Name = "Car",
                Quantity = 10,
                Price = 19999m,
            };
            var motor = new Product()
            {
                Name = "Motorcysle",
                Quantity = 7,
                Price = 9999m,
            };
            var truck = new Product()
            {
                Name = "Truck",
                Quantity = 2,
                Price = 39999m,
            };

            context.Products.Add(car);
            context.Products.Add(motor);
            context.Products.Add(truck);

            //Add Customers
            var pesho = new Customer()
            {
                Name = "Pesho",
                CreditCardNumber = "2398423ourflk",
                Email = "pesho@abv.bg"
            };
            var ivan = new Customer()
            {
                Name = "Ivan",
                CreditCardNumber = "ds77flrjo8wr",
                Email = "ivan@abv.bg"
            };
            var asen = new Customer()
            {
                Name = "Asen",
                CreditCardNumber = "gireuy473y3i4",
                Email = "asen@abv.bg"
            };

            context.Customers.Add(pesho);
            context.Customers.Add(ivan);
            context.Customers.Add(asen);

            //Add Sales
            var sale1 = new Sale()
            {
                Date = DateTime.Now,
                StoreLocation = sofia,
                Product = car,
                Customer = pesho
            };
            var sale2 = new Sale()
            {
                Date = DateTime.Now,
                StoreLocation = plovdiv,
                Product = motor,
                Customer = ivan
            };
            var sale3 = new Sale()
            {
                Date = DateTime.Now,
                StoreLocation = varna,
                Product = truck,
                Customer = asen
            };

            context.Sales.Add(sale1);
            context.Sales.Add(sale2);
            context.Sales.Add(sale3);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
