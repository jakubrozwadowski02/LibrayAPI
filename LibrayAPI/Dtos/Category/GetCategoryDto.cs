using LibrayAPI.Dtos.Book;

namespace LibrayAPI.Dtos.Category
{
    public class GetCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<GetBookDto> Books { get; set; }
    }
}
