namespace CarDealer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Car
    {
        public Car()
        {
            this.Parts = new HashSet<Part>();
            this.Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int TravelledDistance { get; set; }

        public virtual ICollection<Part> Parts { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
