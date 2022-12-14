using LibrayAPI.Dtos.Category;

namespace LibrayAPI.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<GetCategoryDto>> GetAll();
        Task<GetCategoryDto> GetById(int id);
        Task<int> Add(AddCategoryDto addCategory);
        Task Update(int id, UpdateCategoryDto updateCategory);
        Task Delete(int id);
    }
}
