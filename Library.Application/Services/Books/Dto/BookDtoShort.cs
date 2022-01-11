using Library.Application.Dto;

namespace Library.Application.Services.Books.Dto;

public class BookDtoShort : EntityDto
{
    public string Title { get; set; }
    public int PagesAmount { get; set; }
}