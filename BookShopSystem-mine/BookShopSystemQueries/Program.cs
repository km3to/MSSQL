namespace BookShopSystemQueries
{
    using BookShopSystem.Data;
    using BookShopSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {   
            BookShopContext context = new BookShopContext();

            FindProfit(context);
        }

        // 1
        private static void BookTitlesByAgeRestriction(BookShopContext context)
        {
            var input = Console.ReadLine();

            foreach (var book in context.Books.Where(b => b.AgeRestriction.ToString() == input))
            {
                Console.WriteLine(book.Title);
            }
        }
        
        //2
        private static void GoldenBooks(BookShopContext context)
        {
            var collection = context.Books
                .Where(b => b.EditionType.ToString() == "Gold" && b.Copies < 5000)
                .OrderBy(b => b.Id);

            foreach (Book book in collection)
            {
                Console.WriteLine(book.Title);
            }
        }

        //3
        private static void BooksByPrice(BookShopContext context)
        {
            var collection = context.Books
                .Where(b => b.Price < 5 || b.Price > 40)
                .OrderBy(b => b.Id);

            foreach (Book book in collection)
            {
                Console.WriteLine($"{book.Title} - ${book.Price}");
            }
        }

        //4
        private static void NotReleasedBooks(BookShopContext context)
        {
            var year = int.Parse(Console.ReadLine());

            var collection = context.Books
                .Where(b => b.ReleaseDate.Year != year)
                .OrderBy(b => b.Id);

            foreach (Book book in collection)
            {
                Console.WriteLine(book.Title);
            }
        }

        //  5
        private static void BookTitlesByCategory(BookShopContext context)
        {
            string[] input = Console.ReadLine()
                .Split(' ')
                .Select(c => c.ToLower())
                .ToArray();

            foreach (Book book in context.Books)
            {
                if (book.Categories.Any(c => input.Contains(c.Name.ToLower())))
                {
                    Console.WriteLine(book.Title);
                }
            }
        }

        // 6
        private static void BooksReleasedBeforeDate(BookShopContext context)
        {
            DateTime inputDate = DateTime.Parse(Console.ReadLine());

            var collection = context.Books
                .Where(b => b.ReleaseDate < inputDate);

            foreach (Book book in collection)
            {
                Console.WriteLine($"{book.Title} - {book.EditionType} - {book.Price}");
            }
        }

        // 7
        private static void AuthorsSearch(BookShopContext context)
        {
            var inputString = Console.ReadLine();

            var collection = context.Authors
                .Where(a => a.FirstName.EndsWith(inputString));

            foreach (Author author in collection)
            {
                Console.WriteLine($"{author.FirstName} {author.LastName}");
            }
        }

        // 8
        private static void BooksSearch(BookShopContext context)
        {
            var inputString = Console.ReadLine().ToLower();

            var collection = context.Books
                .Where(b => b.Title.ToLower().Contains(inputString));

            foreach (Book book in collection)
            {
                Console.WriteLine(book.Title);
            }
        }

        // 9
        private static void BookTitlesSearch(BookShopContext context)
        {
            var inputString = Console.ReadLine().ToLower();

            var collection = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(inputString))
                .OrderBy(b => b.Id);

            foreach (Book book in collection)
            {
                Console.WriteLine($"{book.Title} ({book.Author.FirstName} {book.Author.LastName})");
            }
        }

        // 10
        private static void CountBooks(BookShopContext context)
        {
            var inputSize = int.Parse(Console.ReadLine());

            var result = context.Books
                .Where(b => b.Title.Length > inputSize).Count();

            Console.WriteLine($"There are {result} books with longer title than {inputSize} symbols");
        }

        //11
        private static void TotalBookCopies(BookShopContext context)
        {
            context.Authors
                .OrderByDescending(a => a.Books.Sum(b => b.Copies))
                .ToList()
                .ForEach(a =>
                {
                    Console.WriteLine($"{a.FirstName} {a.LastName} - {a.Books.Sum(b => b.Copies)}");
                });            
        }

        // 12
        private static void FindProfit(BookShopContext context)
        {
            context.Categories.OrderByDescending(c => c.Books.Sum(b => (b.Price * b.Copies)))
                .ThenBy(c => c.Name)
                .ToList()
                .ForEach(c =>
                {
                    Console.WriteLine($"{c.Name} - ${c.Books.Sum(b => (b.Price * b.Copies))}");
                });
        }

        // 13
        private static void MostRecentBooks(BookShopContext context)
        {
            context.Categories.OrderByDescending(c => c.Books.Count())
               .Where(c => c.Books.Count > 35)
               .Select(c => new
               {
                   c.Name,
                   c.Books
               })
               .ToList()
               .ForEach(c =>
               {
                   Console.WriteLine($"--{c.Name}: {c.Books.Count} books");
                   c.Books.OrderByDescending(b => b.ReleaseDate)
                   .ThenBy(b => b.Title)
                   .Take(3)
                   .Select(b => new
                   {
                       b.Title,
                       b.ReleaseDate
                   }).ToList().ForEach(book =>
                   {
                       Console.WriteLine($"{book.Title} ({book.ReleaseDate.Year})");
                   });
               });
        }

        // 14
        private static void IncreaseBookCopies(BookShopContext context)
        {
            DateTime date = DateTime.Parse("06 - Jun - 2013");
            int addedBooks = 0;
            context.Books.Where(b => b.ReleaseDate > date).ToList().ForEach(b =>
            {
                b.Copies += 44;
                addedBooks += 44;
            });
            context.SaveChanges();
            Console.WriteLine(addedBooks);
        }

        // 15
        private static void RemoveBooks(BookShopContext context)
        {
            context.Books.RemoveRange(context.Books.Where(b => b.Copies < 4200));
            context.SaveChanges();
            Console.WriteLine(context.SaveChanges() + " books were deleted");
        }

        // 16
        private static void StoredProcedure(BookShopContext context)
        {
            string[] names = Console.ReadLine().Split(' ');

            var count = context.Database.SqlQuery<int>($"EXEC dbo.usp_GetBooksCountByAuthor {names[0]}, {names[1]}").First();

            Console.WriteLine($"{names[0]} {names[1]} has written {count} books");
        }
    }
}
