using System.ComponentModel.DataAnnotations;
using HappyTesla.Models;

namespace HappyTesla.Data.Entities;

public class Reservation
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public int StartLocationId { get; set; }
    public int EndLocationId { get; set; }
    public int CarId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Price { get; set; }
    public Location StartLocation { get; set; }
    public Location EndLocation { get; set; }
    public Car Car { get; set; }

    public ReservationsViewModel MapToViewModel()
    {
        return new ReservationsViewModel
        {
            Id = Id,
            StartDate = StartDate,
            EndDate = EndDate,
            Price = Price,
            Car = Car.MapToViewModel(),
            StartLocation = StartLocation.MapToViewModel(),
            EndLocation = EndLocation.MapToViewModel()
        };
    }
}