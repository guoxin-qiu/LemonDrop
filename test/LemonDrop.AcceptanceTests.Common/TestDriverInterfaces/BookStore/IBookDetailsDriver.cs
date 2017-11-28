using TechTalk.SpecFlow;

namespace LemonDrop.AcceptanceTests.Common.TestDriverInterfaces.BookStore
{
    public interface IBookDetailsDriver
    {
        void AddToWarehouse(Table books);
        void OpenBookDetails(string bookId);
        void ShowsBookDetails(Table expectedBookDetails);
    }
}
