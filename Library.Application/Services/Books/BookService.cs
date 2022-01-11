using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Dto;
using Library.Application.Exceptions;
using Library.Application.Extensions;
using Library.Application.Helpers;
using Library.Application.Services.Books.Dto;
using Library.Core.Entities;
using Library.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Services.Books;

public class BookService : IBookService
{
    private readonly LibraryDbContext _dbContext;
    private readonly IMapper _mapper;

    public BookService(LibraryDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BookDto>> GetListAsync(FilterDto filter)
    {
        var books = await _dbContext.Books
            .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
            .WhereIf(dto => EF.Functions.Like(dto.Title, $"%{filter.SearchText}%"),
                !string.IsNullOrWhiteSpace(filter.SearchText))
            .ToListAsync();

        return books;
    }

    public async Task<BookDto> GetByIdAsync(int id)
    {
        var book = await _dbContext.Books
            .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (book == null)
        {
            throw new NotFoundException(ErrorMessages.NotFound((Book b) => b.Id, id));
        }

        return book;
    }

    public async Task<int> CreateAsync(BookDtoInput input)
    {
        var book = _mapper.Map<Book>(input);

        await _dbContext.Books.AddAsync(book);
        await _dbContext.SaveChangesAsync();

        return book.Id;
    }

    public async Task UpdateAsync(int id, BookDtoInput input)
    {
        var book = await _dbContext.Books
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == id);

        if (book == null)
        {
            throw new NotFoundException(ErrorMessages.NotFound((Book b) => b.Id, id));
        }

        _dbContext.Books.Update(book);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var book = await _dbContext.Books
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == id);

        if (book == null)
        {
            throw new NotFoundException(ErrorMessages.NotFound((Book b) => b.Id, id));
        }

        _dbContext.Books.Remove(book);
        await _dbContext.SaveChangesAsync();
    }
}