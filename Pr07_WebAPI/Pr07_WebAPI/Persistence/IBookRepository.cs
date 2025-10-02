using Pr07_WebAPI.Models;

namespace Pr07_WebAPI.Persistence;

public interface IBookRepository
{
    Task AddBook(Book book);
    Task DeleteBook(int id);
    Task UpdateBook(Book book);
    Task<Book>? GetBookById(int id);
    Task<List<Book>> GetAllBooks();
    
}