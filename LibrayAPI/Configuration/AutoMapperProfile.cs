using AutoMapper;
using LibrayAPI.Dtos.Author;
using LibrayAPI.Dtos.Book;
using LibrayAPI.Dtos.Category;
using LibrayAPI.Model;

namespace LibrayAPI.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GetCategoryDto, CategoryModel>();
            CreateMap<AddCategoryDto, CategoryModel>();
            CreateMap<CategoryModel, GetCategoryDto>();
            CreateMap<UpdateCategoryDto, CategoryModel>();

            CreateMap<GetAuthorDto, AuthorModel>();
            CreateMap<AddAuthorDto, AuthorModel>();
            CreateMap<AuthorModel, GetAuthorDto>();
            CreateMap<UpdateAuthorDto, AuthorModel>();

            CreateMap<GetBookDto, BookModel>();
            CreateMap<AddBookDto, BookModel>();
            CreateMap<BookModel, GetBookDto>();
                //.ForMember(m => m.FullNameAuthor, c => c.MapFrom(s => s.Author.Firstname + s.Author.Lastname));
            CreateMap<UpdateBookDto, BookModel>();
        }
    }
}
