using TechTalk.SpecFlow;

namespace LemonDrop.AcceptanceTests.Common.TestDriverInterfaces.BookStore
{
    public interface ISearchDriver
    {
        void Search(string searchTerm);
        void ShowBooks(Table expectedBooks);
        void ShowBooks(string expectedTitlesString);
    }
}
