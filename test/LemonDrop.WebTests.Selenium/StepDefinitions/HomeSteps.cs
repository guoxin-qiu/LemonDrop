using LemonDrop.AcceptanceTests.Common.Support;
using LemonDrop.Website.Mvc.Models;
using LemonDrop.WebTests.Selenium.Support;
using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;

namespace LemonDrop.WebTests.Selenium.StepDefinitions
{
    public class HomeSteps: SeleniumStepsBase
    {
        [When(@"I enter the bookstore")]
        public void WhenIEnterTheBookstore()
        {
            _selenium.NavigateTo("BookStore/Index");
        }

        [Then(@"the home screen should show the following books")]
        public void ThenTheHomeScreenShouldShowTheFollowingBooks(Table expectedBooks)
        {
            var expectedTitles = expectedBooks.Rows.Select(t => t["Title"]);
            var foundBooks = from row in _selenium.FindElements(By.XPath("//table/tbody/tr"))
                             let title = row.FindElement(By.ClassName("title")).Text
                             let author = row.FindElement(By.ClassName("author")).Text
                             let price = row.FindElement(By.ClassName("price")).Text
                             select new Book { Title = title, Author = author };

            BookAssertions.HomeScreenShouldShowInOrder(foundBooks, expectedTitles);
        }
    }
}
