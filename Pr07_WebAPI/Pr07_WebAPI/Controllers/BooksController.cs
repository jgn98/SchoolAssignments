using Microsoft.AspNetCore.Mvc;
using Pr07_WebAPI.Models;
using Pr07_WebAPI.Models.Validations;
using Pr07_WebAPI.Persistence;

namespace Pr07_WebAPI.Controllers;


public class BooksController : Controller
{
    private readonly IBookRepository _bookRepository;
    
    
    public BooksController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet("api/books")]
    public async Task<ActionResult<List<Book>>> GetAll()
    {
        var books = await _bookRepository.GetAllBooks();
        return Ok(books);
    }
    
    [HttpGet("api/books/{id:int}")]
    public async Task<ActionResult<Book>> GetBookById(int id)
    {
        if (id <= 0) return BadRequest();

        var book = await _bookRepository.GetBookById(id);
        if (book is null) return NotFound();

        return Ok(book);
    }
    
    [HttpPost("api/books")]
    public async Task<IActionResult> AddBook([FromBody] Book book)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        book.Id = 0;
        await _bookRepository.AddBook(book);

        return Ok(book);
    }

    [HttpPut("api/books/{id:int}")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        if (id <= 0) return BadRequest();
        if (book is null) return BadRequest();
        
        if (book.Id != 0 && book.Id != id)
            return BadRequest();

        book.Id = id;

        var updated = await _bookRepository.UpdateBook(book);
        if (!updated) return NotFound();

        return Ok(book);
    }

    [HttpDelete("api/books/{id:int}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        if (id <= 0) return BadRequest();
        var deletedBook = await _bookRepository.GetBookById(id);

        var deleted = await _bookRepository.DeleteBook(id);
        if (!deleted) return NotFound();

        return Ok(deletedBook);
    }
    
    
}