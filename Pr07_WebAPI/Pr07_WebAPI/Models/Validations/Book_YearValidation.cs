using System.ComponentModel.DataAnnotations;

namespace Pr07_WebAPI.Models.Validations;

public class Book_YearValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var book = value as Book;

        if (book != null)
        {
            if (book.Year < 1800 || book.Year > 2025)
            {
                return new ValidationResult("Year must be between 1800 and 2025");
            }

        }
        return ValidationResult.Success;
    }
}