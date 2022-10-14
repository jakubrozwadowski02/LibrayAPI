using LibrayAPI.Dtos.Author;

namespace LibrayAPI.Services.AuthorService
{
    public interface IAuthorService
    {
        Task<List<GetAuthorDto>> GetAll();
        Task<GetAuthorDto> GetById(int id);
        Task<int> Add(AddAuthorDto addAuthor);
        Task<bool> Update(int id, UpdateAuthorDto updateAuthor);
        Task<bool> Delete(int id);
    }
}
