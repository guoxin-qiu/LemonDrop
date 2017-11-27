using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
using System.Diagnostics;

namespace LemonDrop.WebTests.Selenium.Support
{
    public class SeleniumController
    {
        public static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(10);
        public static SeleniumController Instance = new SeleniumController();

        public IWebDriver Selenium { get; private set; }

        public void Start()
        {
            if(!(Selenium is null))
            {
                return;
            }

            string appUrl = ConfigurationManager.AppSettings["AppUrl"];

            ChromeOptions chromeOpts = new ChromeOptions();
            chromeOpts.AddArguments("disable-infobars");//close the infobar that chrome is being controlled by automated test
            chromeOpts.AddArguments("--start-maximized");
            chromeOpts.AddArguments("--lang=zh-cn");
            Selenium = new ChromeDriver(chromeOpts);

            Selenium.Manage().Timeouts().ImplicitWait = DefaultTimeout;

            Trace("Selenium started");
        }

        public void Stop()
        {
            if(Selenium is null)
            {
                return;
            }

            try
            {
                Selenium.Quit();
                Selenium.Dispose();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex, "Selenium stop error");
            }

            Selenium = null;
            Trace("Selenium stopped");
        }

        private static void Trace(string message) => Console.WriteLine($"-> {message}");
    }
}
