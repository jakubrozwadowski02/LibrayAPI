using System.ComponentModel.DataAnnotations;

namespace LibrayAPI.Model
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<BookModel> Books { get; set; }
    }
}
