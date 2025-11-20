using Microsoft.EntityFrameworkCore;
using Pr07_WebAPI.Models;

namespace Pr07_WebAPI.Data;

public class BookContext : DbContext
{
    public BookContext(DbContextOptions<BookContext> options)
        : base(options)
    {
    }
    
    public DbSet<Book> Books { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Books");
            entity.HasKey(b => b.Id);

            entity.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(b => b.Year)
                .IsRequired();
        });
        
        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "Clean Code", Author = "Robert C. Martin", Year = 2008 },
            new Book { Id = 2, Title = "The Pragmatic Programmer", Author = "Andrew Hunt & David Thomas", Year = 1999 },
            new Book { Id = 3, Title = "Design Patterns: Elements of Reusable Object-Oriented Software", Author = "Erich Gamma et al.", Year = 1994 },
            new Book { Id = 4, Title = "Refactoring: Improving the Design of Existing Code", Author = "Martin Fowler", Year = 1999 },
            new Book { Id = 5, Title = "Domain-Driven Design: Tackling Complexity in the Heart of Software", Author = "Eric Evans", Year = 2003 }
        );
    }
}
