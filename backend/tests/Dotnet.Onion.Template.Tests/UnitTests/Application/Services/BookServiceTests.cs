using Template.NetCore.Application.Mappers;
using Template.NetCore.Application.Services;
using Template.NetCore.Domain.Books;
using Template.NetCore.Domain.Books.Commands;
using Template.NetCore.Tests.UnitTests.Helpers;
using FluentMediator;
using Moq;
using OpenTracing;
using OpenTracing.Mock;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Template.NetCore.Tests.UnitTests.Application.Services
{
    public class BookServiceTests
    {
        private readonly Mock<IBookRepository> _mockBookRepository = new Mock<IBookRepository>();
        private readonly Mock<ITracer> _mockITracer = new Mock<ITracer>();
        private readonly Mock<IMediator> _mockIMediator = new Mock<IMediator>();

        private readonly BookViewModelMapper _mockBookViewModelMapper = new BookViewModelMapper();

        [Fact]
        public async Task Create_Success()
        {
            //Arrange
            _mockITracer.Setup(x => x.BuildSpan(It.IsAny<string>())).Returns(() => new MockSpanBuilder(new MockTracer(), ""));
            _mockIMediator.Setup(x => x.SendAsync<Book>(It.IsAny<CreateNewBookCommand>(), null))
                .Returns(Task.FromResult(BookHelper.GetBook()));

            //Act

            var bookService = new BookService(_mockBookRepository.Object, _mockBookViewModelMapper, _mockITracer.Object, _mockIMediator.Object);
            var book = BookViewModelHelper.GetBookViewModel();
            var result = await bookService.Create(book);

            //Assert
            Assert.NotNull(result);

            Assert.NotEqual(Guid.Empty, result.Id);

            Assert.NotNull(result.Author);
            Assert.NotNull(result.Title);

            Assert.Equal(book.Author, result.Author);
            Assert.Equal(book.Title, result.Title);
            Assert.Equal(book.Description, result.Description);

            _mockITracer.Verify(x => x.BuildSpan(It.IsAny<string>()), Times.Once);
            _mockIMediator.Verify(x => x.SendAsync<Book>(It.IsAny<CreateNewBookCommand>(), null), Times.Once);
        }
    }
}
