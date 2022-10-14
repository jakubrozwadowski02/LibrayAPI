using LibrayAPI.Dtos.Author;
using LibrayAPI.Services.AuthorService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAuthorDto>>> GetAll()
        {
            return Ok(await _authorService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetAuthorDto>> GetById([FromRoute] int id)
        {
            var author = await _authorService.GetById(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add([FromBody] AddAuthorDto addAuthor)
        {
            var author = await _authorService.Add(addAuthor);

            if (author == 0)
            {
                return BadRequest();
            }

            return Created("api/author/{int}", null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Update([FromRoute] int id, [FromBody] UpdateAuthorDto updateAuthor)
        {
            if (updateAuthor == null)
            {
                return BadRequest();
            }

            var updatedAuthor = await _authorService.Update(id, updateAuthor);

            if (!updatedAuthor)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete([FromRoute] int id)
        {
            var isDeleted = await _authorService.Delete(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
