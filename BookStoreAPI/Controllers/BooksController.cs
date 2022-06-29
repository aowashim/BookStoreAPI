using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStoreAPI.Data;
using BookStoreAPI.Repository;
using System.Threading.Tasks;
using BookStoreAPI.Data.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("")]
        [Authorize]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);

            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost("")]
        [Authorize]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            var id = await _bookRepository.AddBookAsync(book);

            return CreatedAtAction(nameof(GetBookById), new { id, controller = "books" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] Book book, [FromRoute] int id)
        {
            await _bookRepository.UpdateBookAsync(id, book);

            return Ok();
        }

        // for updating only the requested fields
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBookPatch([FromBody] JsonPatchDocument book, [FromRoute] int id)
        {
            await _bookRepository.UpdateBookPatchAsync(id, book);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _bookRepository.DeleteBookAsync(id);

            return Ok();
        }
    }
}
