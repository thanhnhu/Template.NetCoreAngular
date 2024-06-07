using Template.NetCore.Application.Mappers;
using Template.NetCore.Application.ViewModels;
using Template.NetCore.Domain.Books;
using FluentMediator;
using OpenTracing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/*
 * Application service is that layer which initializes and oversees interaction 
 * between the domain objects and services. The flow is generally like this: 
 * get domain object (or objects) from repository, execute an action and put it 
 * (them) back there (or not). It can do more - for instance it can check whether 
 * a domain object exists or not and throw exceptions accordingly. So it lets the 
 * user interact with the application (and this is probably where its name originates 
 * from) - by manipulating domain objects and services. Application services should 
 * generally represent all possible use cases.
 */

namespace Template.NetCore.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly BookViewModelMapper _bookViewModelMapper;
        private readonly ITracer _tracer;
        private readonly IMediator _mediator;

        public BookService(IBookRepository bookRepository, BookViewModelMapper bookViewModelMapper, ITracer tracer, IMediator mediator)
        {
            _bookRepository = bookRepository;
            _bookViewModelMapper = bookViewModelMapper;
            _tracer = tracer;
            _mediator = mediator;
        }

        public async Task<BookViewModel> Create(BookViewModel bookViewModel)
        {
            using (var scope = _tracer.BuildSpan("Create_BookService").StartActive(true))
            {
                var newBookCommand = _bookViewModelMapper.ConvertToNewBookCommand(bookViewModel);

                var bookResult = await _mediator.SendAsync<Book>(newBookCommand);

                return _bookViewModelMapper.ConstructFromEntity(bookResult);
            }
        }

        public async Task<BookViewModel> Update(BookViewModel bookViewModel)
        {
            using (var scope = _tracer.BuildSpan("Create_BookService").StartActive(true))
            {
                var updateBookCommand = _bookViewModelMapper.ConvertToBookCommand(bookViewModel);

                var bookResult = await _mediator.SendAsync<Book>(updateBookCommand);

                return _bookViewModelMapper.ConstructFromEntity(bookResult);
            }
        }

        public async Task Delete(Guid id)
        {
            using (var scope = _tracer.BuildSpan("Delete_BookService").StartActive(true))
            {
                var deleteBookCommand = _bookViewModelMapper.ConvertToDeleteBookCommand(id);
                await _mediator.PublishAsync(deleteBookCommand);
            }
        }

        public async Task<IEnumerable<BookViewModel>> GetAll()
        {
            using (var scope = _tracer.BuildSpan("GetAll_BookService").StartActive(true))
            {
                var booksEntities = await _bookRepository.FindAll();

                return _bookViewModelMapper.ConstructFromListOfEntities(booksEntities);
            }
        }

        public async Task<BookViewModel> GetById(Guid id)
        {
            using (var scope = _tracer.BuildSpan("GetById_BookService").StartActive(true))
            {
                var bookEntity = await _bookRepository.FindById(id);

                return _bookViewModelMapper.ConstructFromEntity(bookEntity);
            }
        }
    }
}
