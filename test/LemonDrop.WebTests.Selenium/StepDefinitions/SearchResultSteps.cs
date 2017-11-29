using FluentAssertions;
using LemonDrop.Website.Mvc.Models;
using LemonDrop.WebTests.Selenium.Support;
using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;

namespace LemonDrop.WebTests.Selenium.StepDefinitions
{
    public class SearchResultSteps : SeleniumStepsBase
    {
        [When(@"I sort the search result table by Author")]
        public void WhenISortTheSearchResultTableByAuthor()
        {
            _selenium.FindElements(By.XPath("//table[@id='searchResultTable']/thead/tr/th/em[text()='Author']")).First().Click();
        }

        [When(@"I sort the search result table by Title")]
        public void WhenISortTheSearchResultTableByTitle()
        {
            _selenium.FindElements(By.XPath("//table[@id='searchResultTable']/thead/tr/th/em[text()='Title']")).First().Click();
        }

        [Then(@"the search result list should display the books in the following order")]
        public void ThenTheSearchResultListShouldDisplayTheBooksInTheFollowingOrder(Table table)
        {
            var expectedBooks = from tableRow in table.Rows
                                let author = tableRow["Author"]
                                let title = tableRow["Title"]
                                select new Book { Author = author, Title = title };

            var tableRows = _selenium.FindElements(By.XPath("//table[@id='searchResultTable']/tbody/tr"));

            var actualBooks = from tr in tableRows
                              let title = tr.FindElement(By.XPath("//td[1]/h4")).Text
                              let author = tr.FindElement(By.XPath("//td[2]")).Text
                              select new Book { Title = title, Author = author };

            actualBooks.Should().Equal(
                expectedBooks,
                (a, e) => a.Title == e.Title && a.Author == e.Author);
        }
    }
}
