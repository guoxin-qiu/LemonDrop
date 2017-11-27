using System.Collections.Generic;
using FluentAssertions;
using LemonDrop.Website.Mvc.Models;

namespace LemonDrop.AcceptanceTests.Support.BookStore
{
    public class ReferenceBookList : Dictionary<string, Book>
    {
        public Book GetByTitle(string bookTitle)
        {
            return this[bookTitle.Trim()].Should().NotBeNull()
                                      .And.Subject.Should().BeOfType<Book>().Which;
        }
    }
}
