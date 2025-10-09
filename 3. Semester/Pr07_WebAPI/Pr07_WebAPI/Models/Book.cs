using Pr07_WebAPI.Models.Validations;

namespace Pr07_WebAPI.Models;

public class Book
{
    public int Id { get; set; }
    [Book_TitleValidation]
    public string Title { get; set; }
    [Book_AuthorValidation]
    public string Author { get; set; }
    [Book_YearValidation]
    public int Year { get; set; }
}