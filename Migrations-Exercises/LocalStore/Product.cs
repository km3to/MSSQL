

namespace LocalStore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Product
    {
        public Product()
        {
        }

        public Product(string name, string distributorName, string description, decimal price)
        {
            this.Name = name;
            this.DistributorName = distributorName;
            this.Description = description;
            this.Price = price;
        }

        public int ProductId { get; set; }

        public string  Name { get; set; }

        public string DistributorName { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
