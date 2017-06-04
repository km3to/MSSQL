namespace Data
{
    using System.Data.Entity;
    using Models;

    public class InitializeAndSeed : DropCreateDatabaseAlways<MoviesContext>
    {
        protected override void Seed(MoviesContext context)
        {
            /*
            var nolan = new Director()
            {
                FirstName = "Christopher",
                LastName = "Nolan"
            };

            var zemeckis = new Director()
            {
                FirstName = "Robert",
                LastName = "Zemeckis"
            };

            var movie1 = new Movie()
            {
                Title = "Interstellar",
                Genre = "Drama/Adventure/Sci-Fi",
                Rating = 8.6f,
                YearOfRelease = 2014,
                Director = nolan
            };

            var movie2 = new Movie()
            {
                Title = "The Dark Knight Rises",
                Genre = "Thriller/Action",
                Rating = 8.4f,
                YearOfRelease = 2012,
                Director = nolan
            };

            var movie3 = new Movie()
            {
                Title = "Contact",
                Genre = "Mystery/Drama/Sci-Fi",
                Rating = 7.6f,
                YearOfRelease = 1997,
                Director = zemeckis
            };

            context.Movies.Add(movie1);
            context.Movies.Add(movie2);
            context.Movies.Add(movie3);

            context.SaveChanges();

            base.Seed(context);
            */
        }
    }
}
