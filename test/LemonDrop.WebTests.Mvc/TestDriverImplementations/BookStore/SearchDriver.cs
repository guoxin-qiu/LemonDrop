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
    public class SearchDriver : ISearchDriver
    {
        private SearchResultState _state;

        public SearchDriver(SearchResultState state)
        {
            _state = state;
        }

        public void Search(string searchTerm)
        {
            var controller = new BookStoreController();
            _state.ActionResult = controller.Search(searchTerm);
        }

        public void ShowBooks(Table expectedBooks)
        {
            var foundBooks = _state.ActionResult.Model<IEnumerable<Book>>();
            var expectedTitles = expectedBooks.Rows.Select(t => t["Title"]);
            BookAssertions.FoundBooksShouldMatchTitlesInOrder(foundBooks, expectedTitles);
        }

        public void ShowBooks(string expectedTitlesString)
        {
            var foundBooks = _state.ActionResult.Model<IEnumerable<Book>>();
            var expectedTitles = from t in expectedTitlesString.Split(',')
                                 select t.Trim().Trim('\'');
            BookAssertions.FoundBooksShouldMatchTitlesInOrder(foundBooks, expectedTitles);
        }
    }

    public class SearchResultState
    {
        public ActionResult ActionResult { get; set; }
    }
}
