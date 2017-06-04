namespace ExtendedQuery.Models
{
    using System.Collections.Generic;

    public class Client
    {
        private ICollection<Order> orders;

        public Client()
        {
            this.orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Order> Orders
        {
            get { return this.orders; }
            set { this.orders = value; }
        }
    }
}
