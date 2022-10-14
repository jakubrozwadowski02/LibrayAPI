using LibrayAPI.Dtos.Category;
using LibrayAPI.Services.CategoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetCategoryDto>>> GetAll()
        {
            return Ok(await _categoryService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCategoryDto>> GetById([FromRoute] int id)
        {
            var category = await _categoryService.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add([FromBody] AddCategoryDto addCategory)
        {
            var category = await _categoryService.Add(addCategory);

            if (category == 0)
            {
                return BadRequest();
            }

            return Created("api/category/{int}", null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Update([FromRoute] int id, [FromBody] UpdateCategoryDto updateCategory)
        {
            if (updateCategory == null)
            {
                return BadRequest();
            }

            var updatedCategory = await _categoryService.Update(id, updateCategory);

            if (!updatedCategory)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete([FromRoute]int id)
        {
            var isDeleted = await _categoryService.Delete(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
