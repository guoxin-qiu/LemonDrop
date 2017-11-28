using LemonDrop.AcceptanceTests.Common.Support;
using LemonDrop.AcceptanceTests.Common.TestDriverInterfaces.BookStore;
using LemonDrop.Website.Mvc.Controllers;
using LemonDrop.Website.Mvc.Models;
using LemonDrop.WebTests.Mvc.Support;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TechTalk.SpecFlow;

namespace LemonDrop.WebTests.Mvc.TestDriverImplementations.BookStore
{
    public class HomeDriver : IHomeDriver
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
