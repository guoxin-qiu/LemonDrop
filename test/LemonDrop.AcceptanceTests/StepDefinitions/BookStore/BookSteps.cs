using LemonDrop.AcceptanceTests.Common.TestDriverInterfaces.BookStore;
using TechTalk.SpecFlow;

namespace LemonDrop.AcceptanceTests.StepDefinitions.BookStore
{
    [Binding]
    public class BookSteps
    {
        private readonly IBookDetailsDriver _driver;

        public BookSteps(IBookDetailsDriver driver)
        {
            _driver = driver;
        }

        [Given(@"the following books")]
        public void GivenTheFollowingBooks(Table givenBooks)
        {
            _driver.AddToWarehouse(givenBooks);
        }

        [When(@"I open the details of '(.*)'")]
        public void WhenIOpenTheDetailsOfBook(string bookId)
        {
            _driver.OpenBookDetails(bookId);
        }

        [Then(@"the book details should show")]
        public void ThenTheBookDetailsShouldShow(Table expectedBookDetails)
        {
            _driver.ShowsBookDetails(expectedBookDetails);
        }
    }
}
