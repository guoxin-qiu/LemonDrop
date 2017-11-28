using LemonDrop.AcceptanceTests.Common.Support;
using LemonDrop.AcceptanceTests.Common.TestDriverInterfaces.BookStore;
using LemonDrop.Website.Mvc.Models;
using LemonDrop.WebTests.Selenium.Support;
using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;

namespace LemonDrop.WebTests.Selenium.TestDriverImplementations
{
    public class HomeDriver : DriverBase, IHomeDriver
    {
        public void Navigate()
        {
            selenium.NavigateTo("BookStore/Index");
        }

        public void ShowsBooks(Table expectedBooks)
        {
            var expectedTitles = expectedBooks.Rows.Select(t => t["Title"]);
            var foundBooks = from row in selenium.FindElements(By.XPath("//table/tbody/tr"))
                             let title = row.FindElement(By.ClassName("title")).Text
                             let author = row.FindElement(By.ClassName("author")).Text
                             let price = row.FindElement(By.ClassName("price")).Text
                             select new Book { Title = title, Author = author };

            BookAssertions.HomeScreenShouldShowInOrder(foundBooks, expectedTitles);
        }
    }
}
