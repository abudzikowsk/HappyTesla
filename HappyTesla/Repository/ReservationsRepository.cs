using HappyTesla.Data;
using HappyTesla.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HappyTesla.Repository;

public class ReservationsRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    
    public ReservationsRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Reservation>> GetAllByUserIdAsync(string userId)
    {
        return await _applicationDbContext.Reservations
            .Include(r => r.StartLocation)
            .Include(r => r.EndLocation)
            .Include(r => r.Car)
            .Where(r => r.UserId == userId)
            .ToListAsync();
    }

    public async Task<Reservation> GetReservationByIdAsync(int id)
    {
        return await _applicationDbContext.Reservations
            .Include(r => r.StartLocation)
            .Include(r => r.EndLocation)
            .Include(r => r.Car)
            .SingleOrDefaultAsync(r => r.Id == id);
    }

    public async Task CreateReservationAsync(string userId, int startLocationId,int endLocationId, int carId, DateTime startDate, DateTime endDate, decimal price)
    {
        var newReservation = new Reservation
        {
            UserId = userId,
            StartLocationId = startLocationId,
            EndLocationId = endLocationId,
            CarId = carId,
            StartDate = startDate,
            EndDate = endDate,
            Price = price
        };
        
        _applicationDbContext.Add(newReservation);
        await _applicationDbContext.SaveChangesAsync();
    }

    public async Task DeleteReservationAsync(int id)
    {
        var reservationToDelete = _applicationDbContext.Reservations
            .SingleOrDefaultAsync(r => r.Id == id);

        if (reservationToDelete == null)
        {
            return;
        }
        _applicationDbContext.Reservations.Remove(await reservationToDelete); //await?
        await _applicationDbContext.SaveChangesAsync();
    }
}