using AutoMapper;
using LibrayAPI.Data;
using LibrayAPI.Dtos.Book;
using LibrayAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace LibrayAPI.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetBookDto>> GetAll()
        {
            var books = await _context.Books
                .Include(x => x.Author)
                .ToListAsync();

            var booksDto = _mapper.Map<List<GetBookDto>>(books);

            return booksDto;
        }

        public async Task<GetBookDto> GetById(int id)
        {
            var book = await _context.Books
                .FirstOrDefaultAsync(c => c.Id == id);

            if (book == null) return null;

            return _mapper.Map<GetBookDto>(book);
        }

        public async Task<int> Add(AddBookDto addBook)
        {
            var book = _mapper.Map<BookModel>(addBook);

            if (book == null) return 0;

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }
        public async Task<bool> Update(int id, UpdateBookDto updateBook)
        {
            var book = await _context.Books
                .FirstOrDefaultAsync(c => c.Id == id);

            if (book == null) return false;
            if (book.Id != id) return false;

            book.Title = updateBook.Title;
            book.ISBN = updateBook.ISBN;
            book.Description = updateBook.Description;
            book.ReleaseDate = updateBook.ReleaseDate;

            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var book = await _context.Books
                .FirstOrDefaultAsync(c => c.Id == id);

            if (book == null) return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
