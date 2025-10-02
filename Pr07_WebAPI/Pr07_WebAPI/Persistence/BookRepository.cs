using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Pr07_WebAPI.Data;
using Pr07_WebAPI.Models;

namespace Pr07_WebAPI.Persistence;

public class BookRepository : IBookRepository
{
    private readonly BookContext _context;
    
    public BookRepository(BookContext context)
    {
        _context = context;
    }
    
    
    public async Task AddBook(Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBook(int id)
    { 
        _context.Books.Remove(GetBookById(id).Result);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateBook(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
    }

    public async Task<Book>? GetBookById(int id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task<List<Book>> GetAllBooks()
    {
        return await _context.Books.ToListAsync();
    }
}