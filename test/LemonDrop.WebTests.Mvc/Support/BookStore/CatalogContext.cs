namespace LemonDrop.WebTests.Mvc.Support.Bookstore
{
    public class CatalogContext
    {
        public CatalogContext()
        {
            ReferenceBooks = new ReferenceBookList();
        }

        public ReferenceBookList ReferenceBooks { get; set; }
    }
}
