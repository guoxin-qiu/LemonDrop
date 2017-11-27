using LemonDrop.AcceptanceTests.Common;
using LemonDrop.AcceptanceTests.Support;
using LemonDrop.AcceptanceTests.Support.BookStore;
using LemonDrop.Website.Mvc.Controllers;
using LemonDrop.Website.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TechTalk.SpecFlow;

namespace LemonDrop.AcceptanceTests.Drivers.BookStore
{
    public class HomeDriver
    {
        private readonly CatalogContext _context;
        private ActionResult _result;

        public HomeDriver(CatalogContext context) => _context = context;

        public void AddToWarehouse(Table books)
        {
            // TODO: books.CreateSet<Book>();

            using(var db = new BookStoreContext())
            {
                foreach (var row in books.Rows)
                {
                    var book = new Book
                    {
                        Author = row["Author"],
                        Title = row["Title"],
                        Price = Convert.ToDecimal(row["Price"])
                    };
                    _context.ReferenceBooks.Add(book.Title, book);
                    db.Books.Add(book);
                }

                db.SaveChanges();
            }
        }

        public void Navigate()
        {
            using(var controller = new BookStoreController())
            {
                _result = controller.Index();
            }
        }

        public void ShowsBooks(Table expectedBooks)
        {
            var expectedTitles = expectedBooks.Rows.Select(t => t["Title"]);
            var shownBooks = _result.Model<IEnumerable<Book>>();
            BookAssertions.HomeScreenShouldShow(shownBooks, expectedTitles);
        }
    }
}
