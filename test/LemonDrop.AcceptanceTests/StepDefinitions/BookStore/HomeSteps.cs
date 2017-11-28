using LemonDrop.AcceptanceTests.Common.TestDriverInterfaces.BookStore;
using TechTalk.SpecFlow;

namespace LemonDrop.AcceptanceTests.StepDefinitions.BookStore
{
    [Binding]
    public class HomeSteps
    {
        private readonly IHomeDriver _homeDriver;

        public HomeSteps(IHomeDriver homeDriver)
        {
            _homeDriver = homeDriver;
        }
        
        [When(@"I enter the bookstore")]
        public void WhenIEnterTheBookstore()
        {
            _homeDriver.Navigate();
        }
        
        [Then(@"the home screen should show the following books")]
        public void ThenTheHomeScreenShouldShowTheFollowingBooks(Table expectedBooks)
        {
            _homeDriver.ShowsBooks(expectedBooks);
        }
    }
}
