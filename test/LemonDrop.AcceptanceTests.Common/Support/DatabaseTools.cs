using LemonDrop.Website.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace LemonDrop.WebTests.Mvc.Support
{
    [Binding]
    public static class DatabaseTools
    {
        [BeforeScenario]
        public static void CleanDatabase()
        {
            using (var db = new BookStoreContext())
            {
                db.Books.RemoveRange(db.Books);
                db.SaveChanges();
            }
        }

        public static List<Book> AddBooksToDb(Table books)
        {
            using (var context = new BookStoreContext())
            {
                context.Books.AddRange(books.CreateSet<Book>());
                context.SaveChanges();

                return context.Books.ToList();
            }
        }
    }
}
