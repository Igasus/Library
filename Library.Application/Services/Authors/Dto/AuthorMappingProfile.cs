using AutoMapper;
using Library.Core.Entities;

namespace Library.Application.Services.Authors.Dto;

public class AuthorMappingProfile : Profile
{
    public AuthorMappingProfile()
    {
        CreateMap<AuthorDtoInput, Author>();
        CreateMap<Author, AuthorDto>();
        CreateMap<Author, AuthorDtoShort>();
    }
}