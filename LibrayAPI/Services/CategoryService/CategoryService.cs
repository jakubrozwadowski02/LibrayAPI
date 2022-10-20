using AutoMapper;
using LibrayAPI.Data;
using LibrayAPI.Dtos.Category;
using LibrayAPI.Exceptions;
using LibrayAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace LibrayAPI.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetCategoryDto>> GetAll()
        {
            var categories = await _context.Categories
                .Include(c => c.Books)
                .ToListAsync();

            var categoriesDtos = _mapper.Map<List<GetCategoryDto>>(categories);

            return categoriesDtos;
        }

        public async Task<GetCategoryDto> GetById(int id)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category is null)
                throw new NotFoundException("Category not found");

            return _mapper.Map<GetCategoryDto>(category);
        }

        public async Task<int> Add(AddCategoryDto addCategory)
        {
            var category = _mapper.Map<CategoryModel>(addCategory);

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return category.Id;
        }
        public async Task Update(int id, UpdateCategoryDto updateCategory)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category is null)
                throw new NotFoundException("Category not found");

            _mapper.Map<CategoryModel>(updateCategory);

            category.Name = updateCategory.Name;
            category.Description = updateCategory.Description;

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
        
        public async Task Delete(int id)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category is null)
                throw new NotFoundException("Category not found");

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

    }
}
