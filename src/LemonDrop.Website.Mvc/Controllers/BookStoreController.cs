using LemonDrop.Website.Mvc.Models;
using System.Linq;
using System.Web.Mvc;

namespace LemonDrop.Website.Mvc.Controllers
{
    public class BookStoreController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new BookStoreContext())
            {
                var books = context.Books.OrderBy(t => t.Price).Take(3).ToList();
                return View(books);
            }
        }
    }
}