using HappyTesla.Data;
using HappyTesla.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HappyTesla.Repository;

public class CarsRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    
    public CarsRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Car> GetCarByIdAsync(int id)
    {
        return await _applicationDbContext.Cars.SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Car>> GetAllCars()
    {
        return await _applicationDbContext.Cars.ToListAsync();
    }
    
    public async Task DeleteCarAsync(int id)
    {
        var carToDelete = await _applicationDbContext.Cars
            .SingleOrDefaultAsync(r => r.Id == id);

        if (carToDelete == null)
        {
            return;
        }
        
        _applicationDbContext.Cars.Remove(carToDelete);
        await _applicationDbContext.SaveChangesAsync();
    }
    
    public async Task CreateCarAsync(string name, string model, decimal price, string color)
    {
        var newCar = new Car
        {
            Name = name,
            Model = model,
            Price = price,
            Color = color
        };
        
        _applicationDbContext.Add(newCar);
        await _applicationDbContext.SaveChangesAsync();
    }
}