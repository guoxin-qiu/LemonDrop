using FluentAssertions;
using LemonDrop.Website.Mvc.Controllers;
using LemonDrop.Website.Mvc.ViewModels;
using LemonDrop.WebTests.Mvc.Support;
using System.Linq;
using System.Web.Mvc;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace LemonDrop.WebTests.Mvc.StepDefinitions
{
    [Binding]
    public class Account_UserRegistration_Steps
    {
        private ActionResult _result;
        private AccountController _accountController;

        public Account_UserRegistration_Steps()
        {
            _accountController = new AccountController();
        }

        [When(@"I submit the following information on Register page")]
        public void WhenISubmitTheFollowingInformationOnRegisterPage(Table table)
        {
            var registrationInfo = table.CreateInstance<RegistrationInfoVM>();
            _accountController.InvokeValidateModel(registrationInfo); // manual call the method
            _result = _accountController.Register(registrationInfo);
        }
        
        [Then(@"I should see the following information on the Welcome page")]
        public void ThenIShouldSeeTheFollowingInformationOnTheWelcomePage(Table welcomeInfo)
        {
            var expectedMsg = welcomeInfo.Rows.Select(t => t["Value"]);

            _result.ShouldBeRdirectToAction("Welcome");
            _result = _accountController.Welcome();
            var actualInfo = _result.Model<WelcomeInfoVM>();
            expectedMsg.Should().Contain(actualInfo.WelcomeMsg);
            expectedMsg.Should().Contain(actualInfo.AccountMsg);
        }
        
        [Then(@"I should see error messages '(.*)' on the Register page")]
        public void ThenIShouldSeeErrorMessagesOnTheRegisterPage(string errorMessages)
        {
            var expectErrorMessages = from t in errorMessages.Split(',')
                                      select t.Trim().Trim('\'');

            _result.ErrorMessages().ShouldBeEquivalentTo(expectErrorMessages);
        }
    }
}
