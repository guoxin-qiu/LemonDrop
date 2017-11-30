using FluentAssertions;
using LemonDrop.WebTests.Selenium.Support;
using System.Linq;
using TechTalk.SpecFlow;

namespace LemonDrop.WebTests.Selenium.StepDefinitions
{
    public class Account_UserRegistration_Steps: SeleniumStepsBase
    {
        [When(@"I submit the following information on Register page")]
        public void WhenISubmitTheFollowingInformationOnRegisterPage(Table table)
        {
            _selenium.NavigateTo("Account/Register");
            _selenium.FillForm(table);
            _selenium.ClickButton("Register");
        }

        [Then(@"I should see the following information on the Welcome page")]
        public void ThenIShouldSeeTheFollowingInformationOnTheWelcomePage(Table welcomeInfo)
        {
            var expectedMsg = welcomeInfo.Rows.Select(t => t["Value"]);
            _selenium.GetAbsolutePageTitle().ShouldBeEquivalentTo("Welcome");
            _selenium.Messages().Should().ContainInOrder(expectedMsg);
        }

        [Then(@"I should see error messages '(.*)' on the Register page")]
        public void ThenIShouldSeeErrorMessagesOnTheRegisterPage(string errorMessages)
        {
            var expectErrorMessages = from t in errorMessages.Split(',')
                                      select t.Trim().Trim('\'');

            _selenium.GetAbsolutePageTitle().ShouldBeEquivalentTo("Register");
            _selenium.ValidationErrors().Should().ContainInOrder(expectErrorMessages);
        }
    }
}
