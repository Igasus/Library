using Library.Application.Dto;
using Library.Application.Services.Books.Dto;

namespace Library.Application.Services.Books;

public interface IBookService
{
    Task<IEnumerable<BookDto>> GetListAsync(FilterDto filter);
    Task<BookDto> GetByIdAsync(int id);
    Task<int> CreateAsync(BookDtoInput input);
    Task UpdateAsync(int id, BookDtoInput input);
    Task DeleteByIdAsync(int id);
}