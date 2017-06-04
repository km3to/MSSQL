namespace Models
{
    using System.Collections.Generic;

    public class Genre
    {
        public Genre()
        {
            this.Movies = new HashSet<Movie>();
        }

        public int GenreId { get; set; }

        public string Value { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
