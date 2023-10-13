using HappyTesla.Models;

namespace HappyTesla.Data.Entities;

public class Car
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public decimal Price { get; set; }
    public string Color { get; set; }

    public CarViewModel MapToViewModel()
    {
        return new CarViewModel()
        {
            Name = Name,
            Model = Model,
            Color = Color
        };
    }
}