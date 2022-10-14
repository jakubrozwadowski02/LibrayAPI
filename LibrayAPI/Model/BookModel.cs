using System.ComponentModel.DataAnnotations;

namespace LibrayAPI.Model
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public int AuthorId { get; set; }
        public AuthorModel? Author { get; set; }
        public string CategoryId { get; set; }
        public CategoryModel? Category { get; set; }
    }
}
