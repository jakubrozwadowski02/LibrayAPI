using LibrayAPI.Dtos.Book;
using LibrayAPI.Services.BookService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetBookDto>>> GetAll()
        {
            return Ok(await _bookService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetBookDto>> GetById([FromRoute] int id)
        {
            var book = await _bookService.GetById(id);

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add([FromBody] AddBookDto addBook)
        {
            await _bookService.Add(addBook);

            return Created("api/author/{int}", null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateBookDto updateBook)
        {
            await _bookService.Update(id, updateBook);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _bookService.Delete(id);

            return NoContent();
        }
    }
}
