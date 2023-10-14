using HappyTesla.Data;
using HappyTesla.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HappyTesla.Repository;

public class LocationsRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public LocationsRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Location>> GetAllLocationsAsync()
    {
        return await _applicationDbContext.Locations.ToListAsync();
    }

    public async Task CreateLocationAsync(string country, string city, string address)
    {
        var newLocation = new Location
        {
            Country = country,
            City = city,
            Address = address
        };
        
        _applicationDbContext.Add(newLocation);
        await _applicationDbContext.SaveChangesAsync();
    }
    public async Task DeleteLocationAsync(int id)
    {
        var locationToDelete = await _applicationDbContext.Locations
            .SingleOrDefaultAsync(r => r.Id == id);

        if (locationToDelete == null)
        {
            return;
        }
        
        _applicationDbContext.Locations.Remove(locationToDelete);
        await _applicationDbContext.SaveChangesAsync();
    }
}