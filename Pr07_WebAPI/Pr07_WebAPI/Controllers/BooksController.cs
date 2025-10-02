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

    [HttpGet]
    [Route("/api/books")]
    public IActionResult GetBooks()
    {
        return Ok(_bookRepository.GetAllBooks());
    }
    
    [HttpGet]
    [Route("/api/books/{id}")]
    public IActionResult GetBookById(int id)
    {
        var book = _bookRepository.GetBookById(id);
        if (book == null)
            return NotFound();
        if (book.Id <= 0)
            return BadRequest();
        return Ok(book);
    }
    
    [HttpPost]
    [Route("/api/books")]
    public IActionResult AddBook([FromBody] Book book)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        book.Id = 0;
        _bookRepository.AddBook(book);
        return Created();
    }

    [HttpPut]
    [Route("/api/books/{id}")]
    public IActionResult UpdateBook([FromBody] Book book)
    {
        if (book.Id <= 0)
            return BadRequest();
        if (_bookRepository.GetBookById(book.Id) == null)
            return NotFound();
        _bookRepository.UpdateBook(book);
        return Ok();
    }

    [HttpDelete]
    [Route("/api/books/{id}")]
    public IActionResult DeleteBook(int id)
    {
        if (id <= 0)
            return BadRequest();
        if (_bookRepository.GetBookById(id) == null)
            return NotFound();
        _bookRepository.DeleteBook(id);
        return Ok();
    }
    
    
}