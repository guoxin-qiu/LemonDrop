using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace LemonDrop.WebTests.Selenium.Support
{
    [Binding, Scope(Tag = "web")]
    public abstract class SeleniumStepsBase
    {
        protected IWebDriver _selenium => SeleniumController.Instance.Selenium;
    }
}
