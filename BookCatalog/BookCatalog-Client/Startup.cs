namespace BookCatalog.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using Bussiness;

    public class Startup
    {
        public static void Main()
        {
            var books = XmlImport.ImportBooks("catalog/books.xml");

            foreach (var book in books)
            {
                BookDML.AddBook(book);
                Console.WriteLine($"Added {book.Title} to Database.");
            }
        }
    }
}
