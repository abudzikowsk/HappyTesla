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
}