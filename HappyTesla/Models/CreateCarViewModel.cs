using System.ComponentModel.DataAnnotations;
using System.Windows.Markup;

namespace HappyTesla.Models;

public class CreateCarViewModel
{
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }
    [Required]
    [MaxLength(255)]
    public string Model { get; set; }
    [Required]
    [Range(0.01, 999999)]
    public decimal Price { get; set; }
    [Required]
    [MaxLength(255)]
    public string Color { get; set; }
}