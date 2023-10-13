using System.ComponentModel.DataAnnotations;

namespace HappyTesla.Attributes;

public class DateInTheFutureAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        var date = value as DateTime?;

        if (date == null)
        {
            return false;
        }

        return date > DateTime.Now;
    }
}