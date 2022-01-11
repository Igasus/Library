using Library.Application.Dto;
using Library.Application.Services.Authors.Dto;

namespace Library.Application.Services.Authors;

public interface IAuthorService
{
    Task<IEnumerable<AuthorDto>> GetListAsync(FilterDto filter);
    Task<AuthorDto> GetByIdAsync(int id);
    Task<int> CreateAsync(AuthorDtoInput input);
    Task UpdateAsync(int id, AuthorDtoInput input);
    Task DeleteByIdAsync(int id);
    Task AddBookAsync(int authorId, int bookId);
    Task RemoveBookAsync(int authorId, int bookId);
}