using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TechTalk.SpecFlow;

namespace LemonDrop.WebTests.Selenium.Support
{
    public static class WebDriverExtensions
    {
        private static string bar_replacer = "#$$#"; // replace '|'

        public static string GetTextBoxValue(this IWebDriver browser, string field)
        {
            var control = GetFieldControl(browser, field);

            return control.GetAttribute("value");
        }

        public static void SetTextBoxValue(this IWebDriver browser, string field, string value)
        {
            var control = GetFieldControl(browser, field);
            var wait = new WebDriverWait(browser, SeleniumController.DefaultTimeout);
            if (!string.IsNullOrEmpty(control.GetAttribute("value")))
            {
                control.Clear();
                wait.Until(_ => string.IsNullOrEmpty(control.GetAttribute("value")));
            }

            control.SendKeys(value);
            System.Threading.Thread.Sleep(100);
        }

        public static void SubmitForm(this IWebDriver browser, string formId = null)
        {
            var form = formId == null ? GetForm(browser) : browser.FindElements(By.Id(formId)).First();
            form.Submit();
            System.Threading.Thread.Sleep(100);
        }

        public static void ClickButton(this IWebDriver browser, string buttonText)
        {
            browser.FindElements(By.XPath(string.Format("(//input[@type='submit'][@value='{0}']|input[@type='button'][@value='{0}']|//button[text()='{0}'])", buttonText))).First().Click();
            System.Threading.Thread.Sleep(100);
        }

        private static IWebElement GetFieldControl(IWebDriver browser, string field)
        {
            var form = GetForm(browser);
            return form.FindElement(By.Id(field));
        }

        private static IWebElement GetForm(IWebDriver browser)
        {
            return browser.FindElements(By.TagName("form")).First();
        }

        public static void NavigateTo(this IWebDriver browser, string relativeUrl)
        {
            browser.Navigate().GoToUrl(new Uri(new Uri(ConfigurationManager.AppSettings["AppUrl"]), relativeUrl));
        }

        public static DropDown GetDropDown(this IWebDriver browser, string id)
        {
            return browser.FindElement(By.Id(id)).AsDropDown();
        }

        public static DropDown AsDropDown(this IWebElement e)
        {
            return new DropDown(e);
        }

        public static string GetAbsolutePageTitle(this IWebDriver browser)
        {
            return browser.Title.Replace(" - LemonDrop", "");
        }

        public static IEnumerable<string> Messages(this IWebDriver browser)
        {
            return browser.FindElements(By.ClassName("message")).Select(t => t.Text);
        }

        public static IEnumerable<string> ErrorMessages(this IWebDriver browser)
        {
            return browser.FindElements(By.ClassName("text-danger")).Select(t => t.Text);
        }

        public static IEnumerable<string> ValidationErrors(this IWebDriver browser)
        {
            return browser.FindElements(By.ClassName("validation-summary-errors"))
                                .SelectMany(t => t.FindElements(By.XPath("//ul/li")))
                                .Select(t => t.Text);
        }

        public static void FillForm(this IWebDriver browser, Table table)
        {
            var inputs = browser.FindElements(By.XPath("//input|//textarea|//select"))
                ?? Enumerable.Empty<IWebElement>();

            var curRow = table.Rows[0];
            foreach (var name in table.Header)
            {
                var curName = name;
                var curCellData = curRow[curName].Replace(bar_replacer, "|");
                var input = inputs.FirstOrDefault(x => x.GetAttribute("name").ToLower() == curName.ToLower());
                if(input is null)
                {
                    input.Should().NotBeNull("Unable to find element name '{0}'", curName);
                }
                var inputType = input.GetAttribute("type");
                switch (inputType)
                {
                    case "radio":
                        var radios = inputs.Where(
                            x =>
                            x.GetAttribute("type") == "radio" &&
                            x.GetAttribute("name").ToLower() == curName.ToLower());
                        var radio = radios.FirstOrDefault(x => x.GetAttribute("value") == curCellData);
                        if (radio is null)
                        {
                            foreach (var r in radios)
                            {
                                if (r.FindElement(By.XPath("./parent::*")).Text == curCellData)//eg: <label><input name="Gender" type="radio">Male</label>
                                {
                                    radio = r;
                                    break;
                                }
                            }
                        }
                        radio.Should().NotBeNull("Unable to locate radio name '{0}' value '{1}'", curName, curCellData);
                        radio.Click();
                        break;
                    case "checkbox":
                        var chkValues = curCellData.Split('^');
                        var chks = inputs.Where(
                            x =>
                            x.GetAttribute("type") == "checkbox" &&
                            x.GetAttribute("name").ToLower() == curName.ToLower());
                        if (chks != null) {
                            foreach (var chk in chks)
                            {
                                if (chkValues.Contains(chk.GetAttribute("value")) ||
                                    chkValues.Contains(chk.FindElement(By.XPath("./parent::*")).Text))
                                {
                                    if (!chk.Selected)
                                        chk.Click();
                                }
                                else
                                {
                                    if (chk.Selected)
                                        chk.Click();
                                }
                            }
                        }
                        chks.Should().NotBeNull("Unable to locate checkbox name '{0}'", curName);
                        break;
                    default:
                        if (string.Equals(input.TagName, "select", StringComparison.OrdinalIgnoreCase))
                        {
                            SelectElement select = new SelectElement(input);
                            if (select.IsMultiple)
                            {
                                select.DeselectAll();
                                curCellData.Split('^').ToList().ForEach(x => select.SelectByText(x));
                            }
                            else
                                select.SelectByText(curCellData);
                        }
                        else
                        {
                            input.SendKeys(curRow[curName]);
                        }
                        break;
                }
            }
        }
    }

    public class DropDown
    {
        private readonly IWebElement _dropDown;

        public DropDown(IWebElement dropDown)
        {
            this._dropDown = dropDown;

            if (dropDown.TagName != "select")
                throw new ArgumentException("Invalid web element type");
        }

        public string SelectedValue
        {
            get
            {
                var selectedOption = _dropDown.FindElements(By.TagName("option")).FirstOrDefault(e => e.Selected);

                return selectedOption?.GetAttribute("value");

            }
            set
            {
                new SelectElement(_dropDown).SelectByValue(value);
            }
        }
    }
}
