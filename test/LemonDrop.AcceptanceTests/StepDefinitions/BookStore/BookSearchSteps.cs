using LemonDrop.AcceptanceTests.Drivers.BookStore;
using System;
using TechTalk.SpecFlow;

namespace LemonDrop.AcceptanceTests.StepDefinitions.BookStore
{
    [Binding]
    public class BookSearchSteps
    {
        private readonly SearchDriver _searchDriver;

        public BookSearchSteps(SearchDriver searchDriver)
        {
            _searchDriver = searchDriver;
        }

        [When(@"I search for books by the phrase '(.*)'")]
        public void WhenISearchForBooksByThePhrase(string phrase)
        {
            _searchDriver.Search(phrase);
        }
        
        [Then(@"the list of found books should be:")]
        public void ThenTheListOfFoundBooksShouldBe(Table expectedBooks)
        {
            _searchDriver.ShowBooks(expectedBooks);
        }

        [Then(@"the list of found books should contain only: ''(.*)''")]
        public void ThenTheListOfFoundBooksShouldContainOnly(string expectedTitles)
        {
            _searchDriver.ShowBooks(expectedTitles);
        }
    }
}
