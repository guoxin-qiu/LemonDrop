using LemonDrop.AcceptanceTests.Drivers.BookStore;
using TechTalk.SpecFlow;

namespace LemonDrop.AcceptanceTests.StepDefinitions.BookStore
{
    [Binding]
    public class HomeSteps
    {
        private readonly HomeDriver _homeDriver;

        public HomeSteps(HomeDriver homeDriver)
        {
            _homeDriver = homeDriver;
        }
        
        [When(@"I enter the shop")]
        public void WhenIEnterTheShop()
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
