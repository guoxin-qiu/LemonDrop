using LemonDrop.AcceptanceTests.Common.Support;
using LemonDrop.AcceptanceTests.Common.TestDriverInterfaces.BookStore;
using LemonDrop.Website.Mvc.Models;
using LemonDrop.WebTests.Selenium.Support;
using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;

namespace LemonDrop.WebTests.Selenium.TestDriverImplementations
{
    public class SearchDriver : DriverBase, ISearchDriver
    {
        public void Search(string searchTerm)
        {
            selenium.NavigateTo("BookStore/Index");
            selenium.SetTextBoxValue("searchTerm", searchTerm);
            selenium.SubmitForm("searchForm");
        }

        public void ShowBooks(Table expectedBooks)
        {
            var expectedTitles = expectedBooks.Rows.Select(r => r["Title"]);
            var foundBooks = from row in selenium.FindElements(By.XPath("//table/tbody/tr"))
                             let title = row.FindElement(By.ClassName("title")).Text
                             let author = row.FindElement(By.ClassName("author")).Text
                             select new Book { Title = title, Author = author };

            BookAssertions.FoundBooksShouldMatchTitlesInOrder(foundBooks, expectedTitles);
        }

        public void ShowBooks(string expectedTitlesString)
        {
            var expectedTitles = expectedTitlesString.Split(',').Select(t => t.Trim().Trim('\''));
            var foundBooks = from row in selenium.FindElements(By.XPath("//table/tbody/tr"))
                             let title = row.FindElement(By.ClassName("title")).Text
                             let author = row.FindElement(By.ClassName("author")).Text
                             select new Book { Title = title, Author = author };

            BookAssertions.FoundBooksShouldMatchTitlesInOrder(foundBooks, expectedTitles);
        }
    }
}
