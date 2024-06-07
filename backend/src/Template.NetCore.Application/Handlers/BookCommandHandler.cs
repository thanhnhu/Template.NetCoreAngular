using Template.NetCore.Domain.Books;
using Template.NetCore.Domain.Books.Commands;
using Template.NetCore.Domain.Books.Events;
using FluentMediator;
using System;
using System.Threading.Tasks;

namespace Template.NetCore.Application.Handlers
{
    public class BookCommandHandler
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMediator _mediator;

        public BookCommandHandler(IBookRepository taskRepository, IMediator mediator)
        {
            _bookRepository = taskRepository;
            _mediator = mediator;
        }

        public async Task<Book> HandleNewBook(CreateNewBookCommand createNewBookCommand)
        {
            var book = new Book()
            {
                Id = Guid.NewGuid(),
                Author = createNewBookCommand.Author,
                Title = createNewBookCommand.Title,
                Description = createNewBookCommand.Description
            };

            var bookCreated = await _bookRepository.Add(book);
            await _bookRepository.SaveChangesAsync();

            // You may raise an event in case you need to propagate this change to other microservices
            await _mediator.PublishAsync(new BookCreatedEvent(bookCreated.Id, bookCreated.Author,
                bookCreated.Title, bookCreated.Description));

            return bookCreated;
        }

        public async Task<Book> HandleUpdateBook(UpdateBookCommand updateBookCommand)
        {
            var book = new Book()
            {
                Id = updateBookCommand.Id,
                Author = updateBookCommand.Author,
                Title = updateBookCommand.Title,
                Description = updateBookCommand.Description
            };

            var bookUpdated = _bookRepository.Update(book);
            await _bookRepository.SaveChangesAsync();

            // You may raise an event in case you need to propagate this change to other microservices
            await _mediator.PublishAsync(new BookUpdatedEvent(bookUpdated.Id, bookUpdated.Author,
                bookUpdated.Title, bookUpdated.Description));

            return bookUpdated;
        }

        public async Task HandleDeleteBook(DeleteBookCommand deleteBookCommand)
        {
            await _bookRepository.Remove(deleteBookCommand.Id);
            await _bookRepository.SaveChangesAsync();

            // You may raise an event in case you need to propagate this change to other microservices
            await _mediator.PublishAsync(new BookDeletedEvent(deleteBookCommand.Id));
        }
    }
}
