using OpenQA.Selenium;

namespace LemonDrop.WebTests.Selenium.Support
{
    public abstract class SeleniumStepsBase
    {
        protected IWebDriver selenium
        {
            get { return SeleniumController.Instance.Selenium; }
        }
    }
}
