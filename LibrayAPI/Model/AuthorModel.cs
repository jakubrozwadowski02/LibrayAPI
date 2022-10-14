namespace LibrayAPI.Model
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int YearOfBirth { get; set; }
        public List<BookModel> Books { get; set; }
    }
}
