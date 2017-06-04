namespace BookCatalog.Bussiness
{
    using System;
    using System.Xml.Linq;
    using System.Linq;
    using System.Collections.Generic;
    using Data.DTO;

    public static class XmlImport
    {
        public static ICollection<BookDTO> ImportBooks(string fileName)
        {
            XDocument xmlDoc = XDocument.Load(fileName);

            var books = xmlDoc.Root.Elements().Select(ParseBook).ToList();

            return books;
        }

        public static BookDTO ParseBook(XElement book)
        {
            var result = new BookDTO
            {
                RefNumber = book.Attribute("id").Value,
                Author = book.Element("author").Value,
                Title = book.Element("title").Value,
                Genre = book.Element("genre").Value,
                Price = decimal.Parse(book.Element("price").Value),
                Published = DateTime.Parse(book.Element("publish_date").Value),
                Description = book.Element("description").Value
            };
            return result;
        }
    }
}
