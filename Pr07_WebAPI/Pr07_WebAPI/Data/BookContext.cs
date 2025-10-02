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
    }
}
