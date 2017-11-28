using System.Collections.Generic;
using FluentAssertions;
using LemonDrop.Website.Mvc.Models;

namespace LemonDrop.WebTests.Mvc.Support.BookStore
{
    public class ReferenceBookList : Dictionary<string, Book>
    {
        public Book GetById(string bookId)
        {
            return this[bookId.Trim()].Should().NotBeNull()
                                      .And.Subject.Should().BeOfType<Book>().Which;
        }
    }
}
