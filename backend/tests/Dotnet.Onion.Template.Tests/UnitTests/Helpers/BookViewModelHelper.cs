using Template.NetCore.Application.ViewModels;
using System;

namespace Template.NetCore.Tests.UnitTests.Helpers
{
    public static class BookViewModelHelper
    {
        public static BookViewModel GetBookViewModel()
        {
            return new BookViewModel
            {
                Id = Guid.NewGuid(),
                Author = "Author",
                Title = "Title",
                Description = "Description"
            };
        }
    }
}
