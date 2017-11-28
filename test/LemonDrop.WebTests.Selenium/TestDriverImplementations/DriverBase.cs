using LemonDrop.WebTests.Selenium.Support;
using OpenQA.Selenium;

namespace LemonDrop.WebTests.Selenium.TestDriverImplementations
{
    public abstract class DriverBase
    {
        protected IWebDriver selenium
        {
            get { return SeleniumController.Instance.Selenium; }
        }
    }
}
