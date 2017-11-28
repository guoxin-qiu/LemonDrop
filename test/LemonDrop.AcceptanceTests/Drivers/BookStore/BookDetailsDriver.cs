using FluentAssertions;
using LemonDrop.AcceptanceTests.Support;
using LemonDrop.AcceptanceTests.Support.BookStore;
using LemonDrop.Website.Mvc.Controllers;
using LemonDrop.Website.Mvc.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using TechTalk.SpecFlow;

namespace LemonDrop.AcceptanceTests.Drivers.BookStore
{
    public class BookDetailsDriver
    {
        private const decimal BookDefaultPrice = 10;
        private readonly CatalogContext _context;
        private ActionResult _result;

        public BookDetailsDriver(CatalogContext context)
        {
            _context = context;
        }

        public void AddToWarehouse(Table books)
        {
            // TODO: books.CreateSet<Book>();

            using (var context = new BookStoreContext())
            {
                foreach (var row in books.Rows)
                {
                    var book = new Book
                    {
                        Author = row["Author"],
                        Title = row["Title"],
                        Price = books.Header.Contains("Price")
                            ? Convert.ToDecimal(row["Price"])
                            : BookDefaultPrice
                    };

                    _context.ReferenceBooks.Add(
                        books.Header.Contains("Id") ? row["Id"] : book.Title,
                        book);

                    context.Books.Add(book);
                }

                context.SaveChanges();
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
