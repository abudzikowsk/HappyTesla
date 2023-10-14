using HappyTesla.Models;

namespace HappyTesla.Data.Entities;

public class Location
{
    public int Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public LocationViewModel MapToViewModel()
    {
        return new LocationViewModel
        {
            Id = Id,
            Country = Country,
            City = City,
            Adress = Address
        };
    }
}