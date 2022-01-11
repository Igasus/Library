using Library.Application.Dto;
using Library.Application.Services.Authors.Dto;

namespace Library.Application.Services.Books.Dto;

public class BookDto : EntityDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int PagesAmount { get; set; }
    
    public AddressDto CreationAddress { get; set; }
    
    public IEnumerable<AuthorDtoShort> Authors { get; set; }
}