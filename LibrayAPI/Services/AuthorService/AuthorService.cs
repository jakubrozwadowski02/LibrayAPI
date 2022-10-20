using AutoMapper;
using LibrayAPI.Data;
using LibrayAPI.Dtos.Author;
using LibrayAPI.Exceptions;
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

            if (author is null)
                throw new NotFoundException("Author is not found");

            return _mapper.Map<GetAuthorDto>(author);
        }

        public async Task<int> Add(AddAuthorDto addAuthor)
        {
            var author = _mapper.Map<AuthorModel>(addAuthor);

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return author.Id;
        }

        public async Task Update(int id, UpdateAuthorDto updateAuthor)
        {
            var author = await _context.Authors
                .FirstOrDefaultAsync(c => c.Id == id);

            if (author is null)
                throw new NotFoundException("Author is not found");

            _mapper.Map<AuthorModel>(updateAuthor);

            author.Firstname = updateAuthor.Firstname;
            author.Lastname = updateAuthor.Lastname;
            author.YearOfBirth = updateAuthor.YearOfBirth;

            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var author = await _context.Authors
                .FirstOrDefaultAsync(c => c.Id == id);

            if (author is null)
                throw new NotFoundException("Author is not found");

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }
    }
}
