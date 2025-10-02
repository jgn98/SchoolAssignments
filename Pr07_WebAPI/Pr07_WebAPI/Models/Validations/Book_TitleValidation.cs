using System.ComponentModel.DataAnnotations;

namespace Pr07_WebAPI.Models.Validations;

public class Book_TitleValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var book = value as Book;

        if (book != null && !string.IsNullOrWhiteSpace(book.Title))
        {
            if (string.IsNullOrWhiteSpace(book.Title))
            {
                return new ValidationResult("Title must be letters or numerical characters");
            }

        }
        return ValidationResult.Success;
    }
}