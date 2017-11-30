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
    public class Bookstore_Home_Steps
    {
        private ActionResult _result;
        
        [When(@"I enter the bookstore")]
        public void WhenIEnterTheBookstore()
        {
            using (var controller = new BookstoreController())
            {
                _result = controller.Index();
            }
        }
        
        [Then(@"the home screen should show the following books")]
        public void ThenTheHomeScreenShouldShowTheFollowingBooks(Table expectedBooks)
        {
            var expectedTitles = expectedBooks.Rows.Select(t => t["Title"]);
            var shownBooks = _result.Model<IEnumerable<Book>>();
            BookAssertions.HomeScreenShouldShow(shownBooks, expectedTitles);
        }
    }
}
