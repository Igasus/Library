using System.ComponentModel.DataAnnotations;
using Library.Application.Dto;

namespace Library.Application.Services.Authors.Dto;

public class AuthorDtoInput
{
    public string FullName { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
    
    public AddressDto BirthAddress { get; set; }
}