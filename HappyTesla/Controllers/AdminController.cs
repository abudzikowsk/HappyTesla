using HappyTesla.Models;
using HappyTesla.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyTesla.Controllers;

[Authorize(Roles = "Admin")]
[Route("{controller}")]
public class AdminController : Controller
{
    private readonly ReservationsRepository _reservationsRepository;
    private readonly CarsRepository _carsRepository;
    private readonly LocationsRepository _locationsRepository;

    public AdminController(ReservationsRepository reservationsRepository, CarsRepository carsRepository,
        LocationsRepository locationsRepository)
    {
        _reservationsRepository = reservationsRepository;
        _carsRepository = carsRepository;
        _locationsRepository = locationsRepository;
    }

    [HttpGet]
    [Route("{action}")]
    public async Task<ActionResult<List<ReservationsViewModel>>> GetAllReservations()
    {
        var allReservations = await _reservationsRepository.GetAllReservationsAsync();

        var result = new List<ReservationsViewModel>();

        foreach (var reservation in allReservations)
        {
            var viewModel = reservation.MapToViewModel();
            result.Add(viewModel);
        }

        return View(result);
    }
    
    [HttpPost]
    [Route("{action}/{reservationId:int}")]
    public async Task<ActionResult> DeleteReservation(int reservationId)
    {
        var reservation = await _reservationsRepository.GetReservationByIdAsync(reservationId);
        
        if (reservation.StartDate > DateTime.Now)
        {
            await _reservationsRepository.DeleteReservationAsync(reservationId);
        }

        return RedirectToAction("GetAllReservations");
    }
    
    [HttpGet]
    [Route("{action}")]
    public async Task<ActionResult<List<LocationViewModel>>> GetAllLocations()
    {
        var allLocations = await _locationsRepository.GetAllLocationsAsync();

        var result = new List<LocationViewModel>();

        foreach (var location in allLocations)
        {
            var viewModel = location.MapToViewModel();
            result.Add(viewModel);
        }

        return View(result);
    }
    
    [HttpGet]
    [Route("{action}")]
    public ActionResult CreateLocation()
    {
        return View();
    }
    
    [HttpPost]
    [Route("{action}")]
    public async Task<ActionResult> CreateLocation(CreateLocationViewModel createLocationViewModel)
    {
        if (!TryValidateModel(createLocationViewModel))
        {
            return View(createLocationViewModel);
        }
        
        await _locationsRepository.CreateLocationAsync(createLocationViewModel.Country, createLocationViewModel.City, createLocationViewModel.Address);

        return RedirectToAction("GetAllLocations");
    }
    
    [HttpPost]
    [Route("{action}/{locationId:int}")]
    public async Task<ActionResult> DeleteLocation(int locationId)
    {
        await _locationsRepository.DeleteLocationAsync(locationId);

        return RedirectToAction("GetAllLocations");
    }

    [HttpGet]
    [Route("{action}")]
    public async Task<ActionResult<List<CarsRepository>>> GetAllCars()
    {
        var allCars = await _carsRepository.GetAllCars();

        var result = new List<CarViewModel>();

        foreach (var car in allCars)
        {
            var viewModel = car.MapToViewModel();
            result.Add(viewModel);
        }

        return View(result);
    }
    
    [HttpGet]
    [Route("{action}")]
    public ActionResult CreateCar()
    {
        return View();
    }
    
    [HttpPost]
    [Route("{action}")]
    public async Task<ActionResult> CreateCar(CreateCarViewModel createCarViewModel)
    {
        if (!TryValidateModel(createCarViewModel))
        {
            return View(createCarViewModel);
        }
        
        await _carsRepository.CreateCarAsync(createCarViewModel.Model, createCarViewModel.Name, createCarViewModel.Price ,createCarViewModel.Color);

        return RedirectToAction("GetAllCars");
    }
    
    [HttpPost]
    [Route("{action}/{carId:int}")]
    public async Task<ActionResult> DeleteCar(int carId)
    {
        await _carsRepository.DeleteCarAsync(carId);

        return RedirectToAction("GetAllCars");
    }
}