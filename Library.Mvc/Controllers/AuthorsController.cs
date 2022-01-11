using Library.Application.Dto;
using Library.Application.Services.Authors;
using Library.Application.Services.Authors.Dto;
using Library.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Mvc.Controllers;

public class AuthorsController : Controller
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    public async Task<IActionResult> Index(string searchText)
    {
        var filter = new FilterDto { SearchText = searchText };
        
        var authors = await _authorService.GetListAsync(filter);

        return View(authors);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var author = await _authorService.GetByIdAsync(id.Value);

        return View(author);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(AuthorDtoInput input)
    {
        var authorId = await _authorService.CreateAsync(input);

        return RedirectToAction(nameof(Details), new { id = authorId });
    }

    public async Task<IActionResult> Update(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var author = await _authorService.GetByIdAsync(id.Value);

        return View(author);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, AuthorDtoInput input)
    {
        await _authorService.UpdateAsync(id, input);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var author = await _authorService.GetByIdAsync(id.Value);

        return View(author);
    }

    [HttpPost]
    public async Task<IActionResult> ConfirmDeletion(int id)
    {
        await _authorService.DeleteByIdAsync(id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> AddBook(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var author = await _authorService.GetByIdAsync(id.Value);

        return View(author);
    }

    [HttpPost]
    public async Task<IActionResult> AddBook(AuthorBookModel model)
    {
        await _authorService.AddBookAsync(model.AuthorId, model.BookId);
        
        return RedirectToAction(nameof(Details), new { id = model.AuthorId });
    }

    public async Task<IActionResult> RemoveBook(int? authorId, int? bookId)
    {
        if (authorId == null || bookId == null)
        {
            return NotFound();
        }

        await _authorService.RemoveBookAsync(authorId.Value, bookId.Value);

        return RedirectToAction(nameof(Details), new { id = authorId });
    }
}