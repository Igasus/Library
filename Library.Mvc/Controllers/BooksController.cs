using Library.Application.Dto;
using Library.Application.Services.Books;
using Library.Application.Services.Books.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Library.Mvc.Controllers;

public class BooksController : Controller
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<IActionResult> Index(string searchText)
    {
        var filter = new FilterDto { SearchText = searchText };
        
        var books = await _bookService.GetListAsync(filter);

        return View(books);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = await _bookService.GetByIdAsync(id.Value);

        return View(book);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(BookDtoInput input)
    {
        var bookId = await _bookService.CreateAsync(input);

        return RedirectToAction(nameof(Details), new { id = bookId });
    }

    public async Task<IActionResult> Update(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = await _bookService.GetByIdAsync(id.Value);

        return View(book);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, BookDtoInput input)
    {
        await _bookService.UpdateAsync(id, input);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = await _bookService.GetByIdAsync(id.Value);

        return View(book);
    }

    [HttpPost]
    public async Task<IActionResult> ConfirmDeletion(int id)
    {
        await _bookService.DeleteByIdAsync(id);

        return RedirectToAction(nameof(Index));
    }
}