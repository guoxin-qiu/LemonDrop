using FluentAssertions;
using LemonDrop.Website.Mvc.Controllers;
using LemonDrop.Website.Mvc.Models;
using LemonDrop.WebTests.Mvc.Support;
using LemonDrop.WebTests.Mvc.Support.Bookstore;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace LemonDrop.WebTests.Mvc.StepDefinitions
{
    [Binding]
    public class Bookstore_ShoppingCart_Steps
    {
        private readonly CatalogContext _catalogContext;

        public Bookstore_ShoppingCart_Steps(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
        }

        [Given(@"I have a shopping cart with: '(.*)'")]
        public void GivenIHaveAShoppingCartWith(string bookIds)
        {
            foreach (string bookId in from i in bookIds.Split(',')
                                      select i.Trim().Trim('\''))
            {
                Place(bookId);
            }
        }

        [When(@"I enter the shop")]
        public void WhenIEnterTheShop()
        {
            //
        }

        [When(@"I place '(.*)' into the shopping cart")]
        public void WhenIPlaceIntoTheShoppingCart(string bookId)
        {
            Place(bookId);
        }

        [When(@"I delete '(.*)' from the shopping cart")]
        public void WhenIDeleteFromTheShoppingCart(string bookId)
        {
            var book = _catalogContext.ReferenceBooks.GetById(bookId);
            using (var controller = GetShoppingCartController())
            {
                controller.DeleteItem(book.Id);
            }
        }

        [When(@"I change the quantity of '(.*)' to (\d+)")]
        public void WhenIChangeTheQuantityOfTo(string bookId, int quantity)
        {
            var book = _catalogContext.ReferenceBooks.GetById(bookId);
            using (var controller = GetShoppingCartController())
            {
                controller.Edit(new ShoppingCartController.EditArguments { BookId = book.Id, Quantity = quantity });
            }
        }

        [Then(@"my shopping cart should be empty")]
        public void ThenMyShoppingCartShouldBeEmpty()
        {
            using (var controller = GetShoppingCartController())
            {
                var actionResult = controller.Index();
                actionResult.Model<ShoppingCart>().Lines.Should().HaveCount(0);
            }
        }

        [Then(@"my shopping cart should contain (\d+) types? of items?")]
        public void ThenMyShoppingCartShouldContainTypesOfItems(int expectedItemTypeCount)
        {
            using (var controller = GetShoppingCartController())
            {
                var actionResult = controller.Index();
                actionResult.Model<ShoppingCart>().Lines.Should().HaveCount(expectedItemTypeCount);
            }
        }

        [Then(@"my shopping cart should contain (\d+) cop(?:y|ies) of '(.*)'")]
        public void ThenMyShoppingCartShouldContainCopiesOf(int expectedQuantity, string expectedBookId)
        {
            var expectedBook = _catalogContext.ReferenceBooks.GetById(expectedBookId);

            using (var controller = GetShoppingCartController())
            {
                var actionResult = controller.Index();
                actionResult.Model<ShoppingCart>().Lines
                            .Should().ContainSingle(ol => ol.Book.Id == expectedBook.Id)
                            .Which.Quantity.Should().Be(expectedQuantity);
            }
        }

        [Then(@"my shopping cart should contain (\d+) items in total")]
        public void ThenMyShoppingCartShouldContainItemsInTotal(int expectedQuantity)
        {
            using (var controller = GetShoppingCartController())
            {
                var actionResult = controller.Index();
                actionResult.Model<ShoppingCart>().Count.Should().Be(expectedQuantity);
            }
        }

        [Then(@"my shopping cart should show a total price of (.*)")]
        public void ThenMyShoppingCartShouldShowATotalPriceOf(decimal expectedTotalPrice)
        {
            using (var controller = GetShoppingCartController())
            {
                var actionResult = controller.Index();
                actionResult.Model<ShoppingCart>().Price.Should().Be(expectedTotalPrice);
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

        private ShoppingCartController GetShoppingCartController()
        {
            var controller = new ShoppingCartController();
            HttpContextStub.SetupController(controller);
            return controller;
        }
    }
}
