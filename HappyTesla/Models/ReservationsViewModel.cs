using HappyTesla.Data.Entities;

namespace HappyTesla.Models;

public class ReservationsViewModel
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Price { get; set; }
    public CarViewModel Car { get; set; }
    public LocationViewModel StartLocation { get; set; }
    public LocationViewModel EndLocation { get; set; }
}