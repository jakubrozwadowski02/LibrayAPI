using AutoMapper;
using LibrayAPI.Data;
using LibrayAPI.Dtos.Author;
using LibrayAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace LibrayAPI.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuthorService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetAuthorDto>> GetAll()
        {
            var authors = await _context.Authors
                .Include(x => x.Books)
                .ToListAsync();

            var authorsDto = _mapper.Map<List<GetAuthorDto>>(authors);

            return authorsDto;
        }

        public async Task<GetAuthorDto> GetById(int id)
        {
            var author = await _context.Authors
                .Include(x => x.Books)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (author == null) return null;

            return _mapper.Map<GetAuthorDto>(author);
        }

        public async Task<int> Add(AddAuthorDto addAuthor)
        {
            var author = _mapper.Map<AuthorModel>(addAuthor);

            if (author == null) return 0;

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return author.Id;
        }
        public async Task<bool> Update(int id, UpdateAuthorDto updateAuthor)
        {
            var author = await _context.Authors
                .FirstOrDefaultAsync(c => c.Id == id);

            if (author == null) return false;
            if (author.Id != id) return false;

            _mapper.Map<AuthorModel>(updateAuthor);

            author.Firstname = updateAuthor.Firstname;
            author.Lastname = updateAuthor.Lastname;
            author.YearOfBirth = updateAuthor.YearOfBirth;

            _context.Authors.Update(author);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var author = await _context.Authors
                .FirstOrDefaultAsync(c => c.Id == id);

            if (author == null) return false;

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
