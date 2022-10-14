using LibrayAPI.Model;
using System.ComponentModel.DataAnnotations;

namespace LibrayAPI.Dtos.Book
{
    public class GetBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
