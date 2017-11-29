using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace LemonDrop.WebTests.Selenium.Support
{
    [Binding, Scope(Tag = "web")]
    public abstract class SeleniumStepsBase
    {
        protected IWebDriver selenium
        {
            get { return SeleniumController.Instance.Selenium; }
        }
    }
}
