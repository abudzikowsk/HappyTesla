using System.ComponentModel.DataAnnotations;
using HappyTesla.Repository;

namespace HappyTesla.Attributes;

public class IsCarAvailableAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var carId = value as int?;
        if (carId == null)
        {
            return new ValidationResult("CarId need to have a value.");
        }
        
        var startDate = validationContext.ObjectInstance.GetType().GetProperty("StartDate")?
            .GetValue(validationContext.ObjectInstance) as DateTime?;
        
        var endDate = validationContext.ObjectInstance.GetType().GetProperty("EndDate")?
            .GetValue(validationContext.ObjectInstance) as DateTime?;
        
        if (startDate is null || endDate is null)
        {
            return new ValidationResult("Start date and end date need to have a value.");
        }
        
        var carRepository = validationContext.GetService<CarsRepository>();

        var isAvailable = carRepository.CheckIfCarIsAvailable(carId.Value, startDate.Value, endDate.Value).Result;

        if (!isAvailable)
        {
            return new ValidationResult(
                "The car is unavailable during the chosen date range; consider selecting an alternative vehicle or adjusting your dates.");
        }
        
        return ValidationResult.Success;
    }
}