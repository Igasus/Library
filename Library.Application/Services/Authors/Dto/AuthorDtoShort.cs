using Library.Application.Dto;

namespace Library.Application.Services.Authors.Dto;

public class AuthorDtoShort : EntityDto
{
    public string FullName { get; set; }
}