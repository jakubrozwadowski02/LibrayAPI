using LibrayAPI.Dtos.Book;

namespace LibrayAPI.Dtos.Author
{
    public class GetAuthorDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int YearOfBirth { get; set; }
        public List<GetBookDto> Books { get; set; }
    }
}
