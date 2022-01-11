using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Dto;
using Library.Application.Exceptions;
using Library.Application.Extensions;
using Library.Application.Helpers;
using Library.Application.Services.Authors.Dto;
using Library.Core.Entities;
using Library.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Services.Authors;

public class AuthorService : IAuthorService
{
    private readonly LibraryDbContext _dbContext;
    private readonly IMapper _mapper;

    public AuthorService(LibraryDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AuthorDto>> GetListAsync(FilterDto filter)
    {
        var authors = await _dbContext.Authors
            .ProjectTo<AuthorDto>(_mapper.ConfigurationProvider)
            .WhereIf(dto => EF.Functions.Like(dto.FullName, $"%{filter.SearchText}%"),
                !string.IsNullOrWhiteSpace(filter.SearchText))
            .ToListAsync();

        return authors;
    }

    public async Task<AuthorDto> GetByIdAsync(int id)
    {
        var author = await _dbContext.Authors
            .ProjectTo<AuthorDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (author == null)
        {
            throw new NotFoundException(ErrorMessages.NotFound((Author b) => b.Id, id));
        }

        return author;
    }

    public async Task<int> CreateAsync(AuthorDtoInput input)
    {
        var author = _mapper.Map<Author>(input);

        await _dbContext.Authors.AddAsync(author);
        await _dbContext.SaveChangesAsync();

        return author.Id;
    }

    public async Task UpdateAsync(int id, AuthorDtoInput input)
    {
        var author = await _dbContext.Authors
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == id);

        if (author == null)
        {
            throw new NotFoundException(ErrorMessages.NotFound((Author b) => b.Id, id));
        }

        _dbContext.Authors.Update(author);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var author = await _dbContext.Authors
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == id);

        if (author == null)
        {
            throw new NotFoundException(ErrorMessages.NotFound((Author b) => b.Id, id));
        }

        _dbContext.Authors.Remove(author);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddBookAsync(int authorId, int bookId)
    {
        var author = await _dbContext.Authors
            .Include(a => a.Books)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == authorId);

        if (author == null)
        {
            throw new NotFoundException(ErrorMessages.NotFound((Author a) => a.Id, authorId));
        }

        var book = await _dbContext.Books
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == bookId);

        if (book == null)
        {
            throw new NotFoundException(ErrorMessages.NotFound((Book b) => b.Id, bookId));
        }
        
        author.Books.Add(book);

        _dbContext.Authors.Update(author);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveBookAsync(int authorId, int bookId)
    {
        var author = await _dbContext.Authors
            .Include(a => a.AuthorsBooks)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == authorId);

        if (author == null)
        {
            throw new NotFoundException(ErrorMessages.NotFound((Author a) => a.Id, authorId));
        }

        var authorBook = author.AuthorsBooks.FirstOrDefault(ab => ab.BookId == bookId);

        if (authorBook == null)
        {
            throw new NotFoundException($"Author {{ Id: {authorId} }} does not have Book {{ Id: {bookId} }}");
        }

        _dbContext.Remove(authorBook);
        await _dbContext.SaveChangesAsync();
    }
}