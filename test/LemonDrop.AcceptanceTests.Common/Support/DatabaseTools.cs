using LemonDrop.Website.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

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
            // TODO: books.CreateSet<Book>();

            using (var context = new BookStoreContext())
            {
                foreach (var row in books.Rows)
                {
                    var book = new Book
                    {
                        Author = row["Author"],
                        Title = row["Title"],
                        Price = books.Header.Contains("Price")
                            ? Convert.ToDecimal(row["Price"])
                            : 10m
                    };

                    context.Books.Add(book);
                }

                context.SaveChanges();

                return context.Books.ToList();
            }
        }
    }
}
