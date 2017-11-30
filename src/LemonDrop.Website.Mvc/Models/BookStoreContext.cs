using System.Data.Entity;

namespace LemonDrop.Website.Mvc.Models
{
    public class BookstoreContext: DbContext
    {
        public BookstoreContext()
            :base("name=BookStoreContext")
        {
            Database.SetInitializer<BookstoreContext>(null);
        }

        public DbSet<Book> Books { get; set; }
    }
}