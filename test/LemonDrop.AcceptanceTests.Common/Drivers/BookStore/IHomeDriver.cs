using TechTalk.SpecFlow;

namespace LemonDrop.AcceptanceTests.Common.Drivers.BookStore
{
    public interface IHomeDriver
    {
        void Navigate();

        void ShowsBooks(Table expectedBooks);
    }
}
