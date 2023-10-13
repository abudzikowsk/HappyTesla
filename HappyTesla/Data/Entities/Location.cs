using HappyTesla.Models;

namespace HappyTesla.Data.Entities;

public class Location
{
    public int Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Adress { get; set; }
    public LocationViewModel MapToViewModel()
    {
        return new LocationViewModel
        {
            Country = Country,
            City = City,
            Adress = Adress
        };
    }
}