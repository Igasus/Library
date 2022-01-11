using Library.Application.Dto;

namespace Library.Application.Services.Books.Dto;

public class BookDtoInput
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int PagesAmount { get; set; }
    
    public AddressDto CreationAddress { get; set; }
}