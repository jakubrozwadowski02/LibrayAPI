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

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Add([FromBody] AddCategoryDto addCategory)
        {
            await _categoryService.Add(addCategory);

            return Created("api/category/{int}", null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryDto updateCategory)
        {
            await _categoryService.Update(id, updateCategory);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            await _categoryService.Delete(id);

            return NoContent();
        }
    }
}
