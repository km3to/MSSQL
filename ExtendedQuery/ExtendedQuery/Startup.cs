namespace ExtendedQuery
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using Models;
    using System.Data.SqlClient;
    using EntityFramework.Extensions;

    public class Startup
    {
        static void Main()
        {
        }

        public ProductDTO MapToDto(Product product)
        {
            var result = new ProductDTO
            {
                Name = product.Name,
                StockQty = product.Orders.Sum(ps => ps.Quan)
            }

            return result;
        }
    }

    public class ProductDTO
    {
        public string Name { get; set; }

        public int StockQty { get; set; }
    }
}
