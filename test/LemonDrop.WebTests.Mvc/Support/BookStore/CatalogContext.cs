﻿namespace LemonDrop.WebTests.Mvc.Support.BookStore
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