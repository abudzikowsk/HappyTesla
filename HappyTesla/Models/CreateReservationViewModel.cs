using System.ComponentModel.DataAnnotations;
using HappyTesla.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HappyTesla.Models;

public class CreateReservationViewModel
{
    [Required]
    public int StartLocationId { get; set; }
    [Required]
    public int EndLocationId { get; set; }
    [Required]
    public int CarId { get; set; }
    
    [Required]
    [DateInTheFuture]
    public DateTime StartDate { get; set; }
    [Required]
    [EndDateAfterStartDate]
    public DateTime EndDate { get; set; }

    public List<SelectListItem>? AllCars { get; set; }
    public List<SelectListItem>? AllLocations { get; set; }
}