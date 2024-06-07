using Template.NetCore.Application.Services;
using Template.NetCore.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Template.NetCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Get Books
        /// </summary>
        /// <returns>Returns a list of All Books</returns>
        [HttpGet]
        [ProducesResponseType(typeof(BookViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _bookService.GetAll());
        }

        /// <summary>
        /// Get Book by ID
        /// </summary>
        /// <param name="id">Book's ID</param>
        /// <returns>Returns a Book by its ID</returns>
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(typeof(BookViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _bookService.GetById(id));
        }

        /// <summary>
        /// Create a new Book
        /// </summary>
        /// <param name="bookViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(BookViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] BookViewModel bookViewModel)
        {
            return Ok(await _bookService.Create(bookViewModel));
        }

        /// <summary>
        /// Update Book
        /// </summary>
        /// <param name="bookViewModel"></param>
        /// <returns></returns>
        [HttpPut("{id}", Name = "Update")]
        [ProducesResponseType(typeof(BookViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put(Guid id, [FromBody] BookViewModel bookViewModel)
        {
            if (id != bookViewModel.Id)
            {
                return BadRequest();
            }

            return Ok(await _bookService.Update(bookViewModel));
        }

        /// <summary>
        /// Delete a Book
        /// </summary>
        /// <param name="id">Book's ID</param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "Delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _bookService.Delete(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
