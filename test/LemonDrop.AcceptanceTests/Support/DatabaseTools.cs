using LemonDrop.Website.Mvc.Models;
using TechTalk.SpecFlow;

namespace LemonDrop.AcceptanceTests.Support
{
    [Binding]
    public class DatabaseTools
    {
        [BeforeScenario]
        public void CleanDatabase()
        {
            using (var db = new BookStoreContext())
            {
                db.Books.RemoveRange(db.Books);
                db.SaveChanges();
            }
        }
    }
}
