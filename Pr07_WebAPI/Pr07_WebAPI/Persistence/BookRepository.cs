using System.Text.Json;
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

    public async Task<bool> DeleteBook(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book is null) return false;

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateBook(Book book)
    {
        var existing = await _context.Books.FindAsync(book.Id);
        if (existing is null) return false;
        
        existing.Title  = book.Title;
        existing.Author = book.Author;
        existing.Year   = book.Year;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Book?> GetBookById(int id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task<List<Book>> GetAllBooks()
    {
        return await _context.Books.ToListAsync();
    }
}