using LibrayAPI.Dtos.Book;

namespace LibrayAPI.Services.BookService
{
    public interface IBookService
    {
        Task<List<GetBookDto>> GetAll();
        Task<GetBookDto> GetById(int id);
        Task<int> Add(AddBookDto addAuthor);
        Task<bool> Update(int id, UpdateBookDto updateAuthor);
        Task<bool> Delete(int id);
    }
}
