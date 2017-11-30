using LemonDrop.Website.Mvc.Models;
using System.Linq;
using System.Web.Mvc;
using LinqKit;

namespace LemonDrop.Website.Mvc.Controllers
{
    public class BookstoreController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new BookstoreContext())
            {
                var books = context.Books.OrderBy(t => t.Price).Take(3).ToList();
                return View(books);
            }
        }

        public ActionResult Search(string searchTerm)
        {
            using( var context = new BookstoreContext())
            {
                var terms = searchTerm?.Split(' ') ?? new string[0];
                var predicate = terms.Aggregate(
                    PredicateBuilder.New<Book>(string.IsNullOrEmpty(searchTerm)),
                    (acc, term) => acc.Or(t => t.Title.Contains(term))
                                      .Or(t => t.Author.Contains(term)));

                var books = context.Books.AsExpandable()
                    .Where(predicate)
                    .OrderBy(t => t.Title)
                    .ToArray();

                return View("List", books);
            }
        }

        public ActionResult Details(int id)
        {
            using(var context = new BookstoreContext())
            {
                var book = context.Books.First(b => b.Id == id);
                return View(book);
            }
        }
    }
}