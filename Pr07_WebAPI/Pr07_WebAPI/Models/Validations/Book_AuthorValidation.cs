using System.ComponentModel.DataAnnotations;

namespace Pr07_WebAPI.Models.Validations;

public class Book_AuthorValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var book = value as Book;

        if (book != null && !string.IsNullOrWhiteSpace(book.Author))
        {
            if (string.IsNullOrWhiteSpace(book.Author))
            {
                return new ValidationResult("Author must be letters or numerical characters");
            }

        }
        return ValidationResult.Success;
    }
}