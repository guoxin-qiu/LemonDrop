using BoDi;
using LemonDrop.AcceptanceTests.Common.TestDriverInterfaces.BookStore;
using LemonDrop.WebTests.Mvc.TestDriverImplementations.BookStore;
using TechTalk.SpecFlow;

namespace LemonDrop.AcceptanceTests.Support
{
    [Binding, Scope(Tag = "BookStore")]
    public class InjectManage
    {
        private readonly IObjectContainer _objectContainer;

        public InjectManage(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeTypes()
        {
            InitializeTypes_Mvc();
            InitializeTypes_Selenium();
        }

        private void InitializeTypes_Mvc()
        {
            _objectContainer.RegisterTypeAs<HomeDriver, IHomeDriver>();
            _objectContainer.RegisterTypeAs<SearchDriver, ISearchDriver>();
            _objectContainer.RegisterTypeAs<BookDetailsDriver, IBookDetailsDriver>();
            _objectContainer.RegisterTypeAs<ShoppingCartDriver, IShoppingCartDriver>();
        }

        private void InitializeTypes_Selenium()
        {
            _objectContainer.RegisterTypeAs<WebTests.Selenium.TestDriverImplementations.HomeDriver, IHomeDriver>();
            _objectContainer.RegisterTypeAs<WebTests.Selenium.TestDriverImplementations.SearchDriver, ISearchDriver>();
        }
    }
}
