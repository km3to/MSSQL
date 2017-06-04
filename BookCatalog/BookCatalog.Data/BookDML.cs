namespace BookCatalog.Data
{
    using DTO;
    using System;
    using System.Linq;
    using Models;

    public static class BookDML
    {
        public static void AddBook(BookDTO book)
        {
            int genreId = GetGenreId(book.Genre);
            int authorId = GetAuthorId(book.Author);

            
            var newBook = new Book
            {
                AuthorId = authorId,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price,
                PublishedOn = book.Published,
                RefNumber = book.RefNumber
            };

            var genre = GetGenre(genreId);
            newBook.Genres.Add(genre);

            using (var context = new BookEntites())
            {
                context.Genres.Attach(genre);
                context.Books.Add(newBook);
                context.SaveChanges();
            }
        }

        public static int GetGenreId(string genreName)
        {
            using (var context = new BookEntites())
            {
                var genre = context.Genres.Where(g => g.Name == genreName).SingleOrDefault();

                if (genre == null)
                {
                    return AddGenre(genreName);
                }

                return genre.Id;
            }
                

            
        }

        public static Genre GetGenre(int genreId)
        {
            using (var context = new BookEntites())
            {
                return context.Genres.Find(genreId);
            }
        }

        public static int AddGenre(string genreName)
        {
            using (var context = new BookEntites())
            {
                var newGenre = new Genre { Name = genreName };
                context.Genres.Add(newGenre);
                context.SaveChanges();

                return newGenre.Id;
            }
        }

        public static int GetAuthorId(string fullName)
        {
            var nameToken = fullName.Split(new [] { ',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            var firstName = nameToken[1];
            var lastName = nameToken[0];

            using (var context = new BookEntites())
            {
                var author = context.Authors.Where(a => a.FirstName == firstName && a.LastName == lastName).SingleOrDefault();

                if (author == null)
                {
                    return AddAuthor(firstName, lastName);
                }

                return author.Id;
            }
        }

        public static int AddAuthor(string firstName, string lastName)
        {
            var author = new Author
            {
                FirstName = firstName,
                LastName = lastName
            };

            using (var context = new BookEntites())
            {
                context.Authors.Add(author);
                context.SaveChanges();

                return author.Id;
            }
        }
    }
}
