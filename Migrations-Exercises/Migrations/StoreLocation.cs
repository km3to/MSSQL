namespace Migrations
{
    using System.Collections.Generic;

    public class StoreLocation
    {
        public StoreLocation()
        {
            this.SalesInStore = new HashSet<Sale>();
        }

        public int StoreLocationId { get; set; }

        public string LocationName { get; set; }

        public virtual ICollection<Sale> SalesInStore { get; set; }
    }
}
