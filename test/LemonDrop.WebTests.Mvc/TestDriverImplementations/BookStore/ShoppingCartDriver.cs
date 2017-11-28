using FluentAssertions;
using LemonDrop.AcceptanceTests.Common.TestDriverInterfaces.BookStore;
using LemonDrop.Website.Mvc.Controllers;
using LemonDrop.Website.Mvc.Models;
using LemonDrop.WebTests.Mvc.Support;
using LemonDrop.WebTests.Mvc.Support.BookStore;
using System;
using System.Linq;

namespace LemonDrop.WebTests.Mvc.TestDriverImplementations.BookStore
{
    public class ShoppingCartDriver : IShoppingCartDriver
    {
        private readonly CatalogContext _catalogContext;

        public ShoppingCartDriver(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
        }

        public void SetShoppingCart(string bookIds)
        {
            foreach (string bookId in from i in bookIds.Split(',')
                                      select i.Trim().Trim('\''))
            {
                Place(bookId);
            }
        }

        public void Place(string bookId)
        {
            var book = _catalogContext.ReferenceBooks.GetById(bookId);
            using (var controller = GetShoppingCartController())
            {
                controller.Add(book.Id);
            }
        }

        public void Delete(string bookId)
        {
            var book = _catalogContext.ReferenceBooks.GetById(bookId);
            using (var controller = GetShoppingCartController())
            {
                controller.DeleteItem(book.Id);
            }
        }

        public void SetQuantity(string bookId, int quantity)
        {
            var book = _catalogContext.ReferenceBooks.GetById(bookId);
            using (var controller = GetShoppingCartController())
            {
                controller.Edit(new ShoppingCartController.EditArguments { BookId = book.Id, Quantity = quantity });
            }
        }

        public void ContainsTypesOfItems(int expectedAmount)
        {
            using (var controller = GetShoppingCartController())
            {
                var actionResult = controller.Index();
                actionResult.Model<ShoppingCart>().Lines.Should().HaveCount(expectedAmount);
            }
        }

        public void ContainsTotalItems(int expectedQuantity)
        {
            using (var controller = GetShoppingCartController())
            {
                var actionResult = controller.Index();
                actionResult.Model<ShoppingCart>().Count.Should().Be(expectedQuantity);
            }
        }

        public void ShowsTotalPriceOf(decimal expectedTotalPrice)
        {
            using (var controller = GetShoppingCartController())
            {
                var actionResult = controller.Index();
                actionResult.Model<ShoppingCart>().Price.Should().Be(expectedTotalPrice);
            }
        }

        public void ContainsCopiesOf(string bookId, int expectedQuantity)
        {
            var expectedBook = _catalogContext.ReferenceBooks.GetById(bookId);

            using (var controller = GetShoppingCartController())
            {
                var actionResult = controller.Index();
                actionResult.Model<ShoppingCart>().Lines
                            .Should().ContainSingle(ol => ol.Book.Id == expectedBook.Id)
                            .Which.Quantity.Should().Be(expectedQuantity);
            }
        }

        private static ShoppingCartController GetShoppingCartController()
        {
            var controller = new ShoppingCartController();
            HttpContextStub.SetupController(controller);
            return controller;
        }
    }
}
