using TechTalk.SpecFlow;

namespace LemonDrop.AcceptanceTests.Common.TestDriverInterfaces.BookStore
{
    public interface IHomeDriver
    {
        void Navigate();
        void ShowsBooks(Table expectedBooks);
    }
}
