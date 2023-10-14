using System.ComponentModel.DataAnnotations;

namespace HappyTesla.Models;

public class CreateLocationViewModel
{
    [Required]
    [MaxLength(255)]
    public string Country { get; set; }
    [Required]
    [MaxLength(255)]
    public string City { get; set; }
    [Required]
    [MaxLength(255)]
    public string Address { get; set; }
}