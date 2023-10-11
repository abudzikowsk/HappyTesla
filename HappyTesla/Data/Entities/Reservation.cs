using HappyTesla.Models;

namespace HappyTesla.Data.Entities;

public class Reservation
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public int LocationId { get; set; }
    public int CarId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Price { get; set; }

    public Location Location { get; set; }
    public Car Car { get; set; }

    public ReservationsViewModel MapToViewModel()
    {
        return new ReservationsViewModel
        {
            Id = Id,
            LocationId = LocationId,
            CarId = CarId,
            StartDate = StartDate,
            EndDate = EndDate,
            Price = Price
        };
    }
}