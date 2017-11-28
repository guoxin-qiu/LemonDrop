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
        private ActionResult _result;

        public void Navigate()
        {
            using (var controller = new BookStoreController())
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
