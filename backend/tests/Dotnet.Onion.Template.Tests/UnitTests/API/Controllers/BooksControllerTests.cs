using Template.NetCore.API.Controllers;
using Template.NetCore.Application.Services;
using Template.NetCore.Application.ViewModels;
using Template.NetCore.Tests.UnitTests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Template.NetCore.Tests.UnitTests.API.Controllers
{
    public class BooksControllerTests
    {
        private readonly Mock<IBookService> _mockBookService = new Mock<IBookService>();

        [Fact]
        public async Task Create_Success()
        {
            var book = BookViewModelHelper.GetBookViewModel();
            //Arrange
            _mockBookService.Setup(x => x.Create(It.IsAny<BookViewModel>()))
                .Returns(Task.FromResult(book));

            //Act

            var controller = new BooksController(_mockBookService.Object);
            var contentResult = await controller.Post(book);

            //Assert
            Assert.NotNull(contentResult);
            Assert.IsAssignableFrom<OkObjectResult>(contentResult);

            var objectResult = ((OkObjectResult)contentResult).Value;
            Assert.NotNull(objectResult);
            Assert.IsAssignableFrom<BookViewModel>(objectResult);

            var result = objectResult as BookViewModel;

            Assert.Equal(book.Id, result.Id);

            Assert.NotNull(result.Author);
            Assert.NotNull(result.Title);

            Assert.Equal(book.Author, result.Author);
            Assert.Equal(book.Title, result.Title);
            Assert.Equal(book.Description, result.Description);

            _mockBookService.Verify(x => x.Create(It.IsAny<BookViewModel>()), Times.Once);
        }
    }
}
