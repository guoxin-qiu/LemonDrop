using System.Data.Entity;

namespace LemonDrop.Website.Mvc.Models
{
    public class BookStoreContext: DbContext
    {
        public BookStoreContext()
            :base("name=BookStoreContext")
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}