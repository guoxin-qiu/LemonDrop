using FluentAssertions;
using LemonDrop.AcceptanceTests.Common.TestDriverInterfaces.BookStore;
using LemonDrop.Website.Mvc.Controllers;
using LemonDrop.Website.Mvc.Models;
using LemonDrop.WebTests.Mvc.Support;
using LemonDrop.WebTests.Mvc.Support.BookStore;
using System;
using System.Linq;
using System.Web.Mvc;
using TechTalk.SpecFlow;

namespace LemonDrop.WebTests.Mvc.TestDriverImplementations.BookStore
{
    public class BookDetailsDriver : IBookDetailsDriver
    {
        private const decimal BookDefaultPrice = 10; // need to config
        private readonly CatalogContext _context;
        private ActionResult _result;

        public BookDetailsDriver(CatalogContext context)
        {
            _context = context;
        }

        public void AddToWarehouse(Table books)
        {
            var booksFromDb = DatabaseTools.AddBooksToDb(books);

            foreach (var book in booksFromDb)
            {
                _context.ReferenceBooks.Add(book.Title, book);
            }
        }

        public void OpenBookDetails(string bookId)
        {
            var book = _context.ReferenceBooks.GetById(bookId);
            using (var controller = new BookStoreController())
            {
                _result = controller.Details(book.Id);
            }
        }

        public void ShowsBookDetails(Table expectedBookDetails)
        {
            var shownBookDetails = _result.Model<Book>();
            var row = expectedBookDetails.Rows.Single();

            shownBookDetails.Should().Match<Book>(
                b => b.Title == row["Title"]
                && b.Author == row["Author"]
                && b.Price == decimal.Parse(row["Price"]));
        }
    }
}
