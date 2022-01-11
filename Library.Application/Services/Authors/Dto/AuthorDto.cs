using System.ComponentModel.DataAnnotations;
using Library.Application.Dto;
using Library.Application.Services.Books.Dto;

namespace Library.Application.Services.Authors.Dto;

public class AuthorDto : EntityDto
{
    public string FullName { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
    
    public AddressDto BirthAddress { get; set; }
    
    public IEnumerable<BookDtoShort> Books { get; set; }
}