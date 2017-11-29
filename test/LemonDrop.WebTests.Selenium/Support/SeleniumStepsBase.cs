using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace LemonDrop.WebTests.Selenium.Support
{
    [Binding, Scope(Tag = "web")]
    public abstract class SeleniumStepsBase
    {
        protected IWebDriver _selenium => SeleniumController.Instance.Selenium;

        private Table BuildTable<T>(IEnumerable<T> rows)
        {
            var properties = typeof(T).GetProperties();
            var table = new Table(properties.Select(x => x.Name).ToArray());
            foreach (var row in rows)
            {
                var row1 = row;
                table.AddRow(properties.Select(p => Convert.ToString(p.GetValue(row1, null))).ToArray());
            }

            return table;
        }
    }
}
