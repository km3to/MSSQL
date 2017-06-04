namespace ProductsShop.Client
{
    using Models;
    using Newtonsoft.Json;
    using ProductsShop.Data;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main(string[] args)
        {
            ProductsShopContext context = new ProductsShopContext();

            ImportUsers(context);
            ImportProducts(context);
            ImportCategories(context);

            //Querry1(context);
            //Querry2(context);
            //Querry3(context);
            //Querry4(context);
        }

        

        private static void Querry4(ProductsShopContext context)
        {
            var users = context.Users
                            .Include("SoldProducts")
                            .Where(u => u.SoldProducts.Count() > 0)
                            .Select(u => new
                            {
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                Age = u.Age,
                                SoldProductsCount = u.SoldProducts.Count(),
                                SoldProducts = new
                                {
                                    Count = u.SoldProducts.Count(),
                                    Products = u.SoldProducts.Select(p => new
                                    {
                                        Name = p.Name,
                                        Price = p.Price
                                    })
                                }
                            });

            string json = JsonConvert.SerializeObject(new
            {
                UsersCount = users.Count(),
                Users = users
            }, Formatting.Indented);

            Console.WriteLine(json);
        }

        private static void Querry3(ProductsShopContext context)
        {
            var categories = context.Categories
                .Include("Products")
                .OrderBy(c => c.Name)
                .Where(c => c.Products.Count() > 0)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.Products.Count(),
                    averagePrice = c.Products.Average(x => x.Price),
                    totalRevenue = c.Products.Sum(x => x.Price)
                });

            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            Console.WriteLine(json);
        }

        private static void Querry2(ProductsShopContext context)
        {
            var users = context.Users
                .Include("SoldProducts")
                .Where(u => u.SoldProducts.Count() > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.SoldProducts.Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    })
                });

            string json = JsonConvert.SerializeObject(users, Formatting.Indented);

            Console.WriteLine(json);
        }

        private static void Querry1(ProductsShopContext context)
        {
            var products = context.Products
                            .Include("Seller")
                            .Where(p => p.Price >= 500 && p.Price <= 1000)
                            .OrderBy(p => p.Price)
                            .Select(p => new
                            {
                                name = p.Name,
                                price = p.Price,
                                seller = p.Seller.FirstName + " " + p.Seller.LastName
                            });

            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void ImportCategories(ProductsShopContext context)
        {
            string categoriesJson = File.ReadAllText("../../Import/categories.json");

            HashSet<Category> categories = JsonConvert.DeserializeObject<HashSet<Category>>(categoriesJson);

            int number = 0;
            int productCount = context.Products.Count();
            foreach (Category c in categories)
            {
                int categoryProductsCount = number % 3;
                for (int i = 0; i < categoryProductsCount; i++)
                {
                    c.Products.Add(context.Products.Find(number % productCount + 1));
                }

                number++;
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void ImportProducts(ProductsShopContext context)
        {
            string productsJson = File.ReadAllText("../../Import/products.json");

            HashSet<Product> products = JsonConvert.DeserializeObject<HashSet<Product>>(productsJson);

            int number = 0;
            int usersCount = context.Users.Count();
            foreach (var p in products)
            {
                p.SellerId = (number % usersCount) + 1;
                if (number % 3 == 0)
                {
                    p.BuyerId = (number * 2 % usersCount) + 1;
                }
                number++;
            }

            context.Products.AddRange(products);
            context.SaveChanges();
            
        }

        private static void ImportUsers(ProductsShopContext context)
        {
            string usersJson = File.ReadAllText("../../Import/users.json");

            HashSet<User> users = JsonConvert.DeserializeObject<HashSet<User>>(usersJson);

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
