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

    public async Task<List<Location>> GetAllLocations()
    {
        return await _applicationDbContext.Locations.ToListAsync();
    }
}