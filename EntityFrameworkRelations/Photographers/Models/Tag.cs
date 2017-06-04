namespace Photographers.Models
{
    using Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Tag
    {
        public Tag()
        {
            this.Albums = new HashSet<Album>();
        }

        public int Id { get; set; }

        [Tag]
        [CustomMinLength(MinLengthValue = 5)]
        public string Label { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
