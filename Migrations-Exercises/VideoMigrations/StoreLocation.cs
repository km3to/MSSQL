using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoMigrations
{
    public class StoreLocation
    {
        public int Id { get; set; }

        public string LocationName { get; set; }

        public ICollection<Sale> SalesInStore { get; set; }
    }
}
