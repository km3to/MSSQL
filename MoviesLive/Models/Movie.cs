namespace Models
{
    using System.Collections.Generic;

    public class Movie
    {
        public Movie()
        {
            this.Actors = new HashSet<Actor>();
            this.Genres = new HashSet<Genre>();
        }

        public int MovieId { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public int YearOfRelease { get; set; }

        public float Rating { get; set; }

        public ushort Duration { get; set; }

        public int DirectorId { get; set; }

        public virtual Director Director { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
    }
}
