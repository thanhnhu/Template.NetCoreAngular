using Template.NetCore.Application.ViewModels;
using Template.NetCore.Domain.Books;
using Template.NetCore.Domain.Books.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

/*
 * A view model represents the data that you want to display on 
 * your view/page, whether it be used for static text or for input
 * values (like textboxes and dropdown lists). It is something 
 * different than your domain model. So we need to convert the 
 * domain model to a view model to send it to the client (API response)
 * 
 * This is an example of the mapping, you can use whatever you want in
 * your code, Automapper or any similar library to do this conversion.
 */

namespace Template.NetCore.Application.Mappers
{
    public class BookViewModelMapper
    {
        public BookViewModelMapper() { }

        public IEnumerable<BookViewModel> ConstructFromListOfEntities(IEnumerable<Book> books)
        {
            var booksViewModel = books.Select(r => new BookViewModel
            {
                Id = r.Id,
                Author = r.Author,
                Title = r.Title,
                Description = r.Description
            });

            return booksViewModel;
        }

        public BookViewModel ConstructFromEntity(Book book)
        {
            return new BookViewModel
            {
                Id = book.Id,
                Author = book.Author,
                Title = book.Title,
                Description = book.Description
            };
        }

        public CreateNewBookCommand ConvertToNewBookCommand(BookViewModel bookVM)
        {
            return new CreateNewBookCommand(bookVM.Author, bookVM.Title, bookVM.Description);
        }

        public UpdateBookCommand ConvertToBookCommand(BookViewModel bookVM)
        {
            return new UpdateBookCommand(bookVM.Id, bookVM.Author, bookVM.Title, bookVM.Description);
        }

        public DeleteBookCommand ConvertToDeleteBookCommand(Guid id)
        {
            return new DeleteBookCommand(id);
        }
    }
}
