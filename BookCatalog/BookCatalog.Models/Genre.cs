namespace BookCatalog.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Genre
    {
        public int Id { get; set; }


        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
