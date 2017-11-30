using LemonDrop.AcceptanceTests.Common.Support;
using LemonDrop.Website.Mvc.Controllers;
using LemonDrop.Website.Mvc.Models;
using LemonDrop.WebTests.Mvc.Support;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TechTalk.SpecFlow;

namespace LemonDrop.WebTests.Mvc.StepDefinitions
{
    [Binding]
    public class Bookstore_BookSearch_Steps
    {
        private ActionResult _result;

        [When(@"I search for books by the phrase '(.*)'")]
        public void WhenISearchForBooksByThePhrase(string phrase)
        {
            var controller = new BookstoreController();
            _result = controller.Search(phrase);
        }
        
        [Then(@"the list of found books should be:")]
        public void ThenTheListOfFoundBooksShouldBe(Table expectedBooks)
        {
            var foundBooks = _result.Model<IEnumerable<Book>>();
            var expectedTitles = expectedBooks.Rows.Select(t => t["Title"]);
            BookAssertions.FoundBooksShouldMatchTitlesInOrder(foundBooks, expectedTitles);
        }

        [Then(@"the list of found books should contain only: ''(.*)''")]
        public void ThenTheListOfFoundBooksShouldContainOnly(string expectedTitlesString)
        {
            var foundBooks = _result.Model<IEnumerable<Book>>();
            var expectedTitles = from t in expectedTitlesString.Split(',')
                                 select t.Trim().Trim('\'');
            BookAssertions.FoundBooksShouldMatchTitlesInOrder(foundBooks, expectedTitles);
        }
    }
}
