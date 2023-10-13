using System.ComponentModel.DataAnnotations;

namespace HappyTesla.Attributes;

public class EndDateAfterStartDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var startDate = validationContext.ObjectInstance.GetType().GetProperty("StartDate")?
            .GetValue(validationContext.ObjectInstance) as DateTime?;

        var endDate = value as DateTime?;

        if (startDate is null || endDate is null)
        {
            return new ValidationResult("Start date and end date need to have a value.");
        }

        if (startDate > endDate)
        {
            return new ValidationResult("Start date need to be before end date.");
        }

        return ValidationResult.Success;
    }
}