using Template.NetCore.Domain.Books;
using System;
using System.Collections.Generic;

namespace Template.NetCore.Tests.UnitTests.Helpers
{
    public static class BookHelper
    {
        public static Book GetBook()
        {
            return new Book()
            {
                Id = Guid.NewGuid(),
                Author = "Author",
                Title = "Title",
                Description = "Description"
            };
        }

        public static IEnumerable<Book> GetBooks()
        {
            return new List<Book>()
            {
                GetBook()
            };
        }
    }
}
