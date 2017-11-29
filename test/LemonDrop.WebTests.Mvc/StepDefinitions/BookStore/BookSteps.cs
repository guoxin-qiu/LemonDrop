using FluentAssertions;
using LemonDrop.Website.Mvc.Controllers;
using LemonDrop.Website.Mvc.Models;
using LemonDrop.WebTests.Mvc.Support;
using LemonDrop.WebTests.Mvc.Support.BookStore;
using System.Linq;
using System.Web.Mvc;
using TechTalk.SpecFlow;

namespace LemonDrop.WebTests.Mvc.StepDefinitions.BookStore
{
    [Binding]
    public class BookSteps
    {
        private readonly CatalogContext _context;
        private ActionResult _result;

        public BookSteps(CatalogContext context)
        {
            _context = context;
        }

        [Given(@"the following books")]
        public void GivenTheFollowingBooks(Table givenBooks)
        {
            var booksFromDb = DatabaseTools.AddBooksToDb(givenBooks);

            foreach (var book in booksFromDb)
            {
                _context.ReferenceBooks.Add(book.Title, book);
            }
        }

        [When(@"I open the details of '(.*)'")]
        public void WhenIOpenTheDetailsOfBook(string bookId)
        {
            var book = _context.ReferenceBooks.GetById(bookId);
            using (var controller = new BookStoreController())
            {
                _result = controller.Details(book.Id);
            }
        }

        [Then(@"the book details should show")]
        public void ThenTheBookDetailsShouldShow(Table expectedBookDetails)
        {
            var shownBookDetails = _result.Model<Book>();
            var row = expectedBookDetails.Rows.Single();

            shownBookDetails.Should().Match<Book>(
                b => b.Title == row["Title"]
                && b.Author == row["Author"]
                && b.Price == decimal.Parse(row["Price"]));
        }
    }
}
