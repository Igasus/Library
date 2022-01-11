using AutoMapper;
using Library.Core.Entities;

namespace Library.Application.Services.Books.Dto;

public class BookMappingProfile : Profile
{
    public BookMappingProfile()
    {
        CreateMap<BookDtoInput, Book>();
        CreateMap<Book, BookDto>();
        CreateMap<Book, BookDtoShort>();
    }
}