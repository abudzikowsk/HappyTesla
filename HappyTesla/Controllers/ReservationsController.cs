using System.Security.Claims;
using HappyTesla.Models;
using HappyTesla.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HappyTesla.Controllers;

[Authorize]
[Route("{controller}")]
public class ReservationsController : Controller
{
    private readonly ReservationsRepository _reservationsRepository;
    private readonly CarsRepository _carsRepository;
    private readonly LocationsRepository _locationsRepository;

    public ReservationsController(ReservationsRepository reservationsRepository, CarsRepository carsRepository, LocationsRepository locationsRepository)
    {
        _reservationsRepository = reservationsRepository;
        _carsRepository = carsRepository;
        _locationsRepository = locationsRepository;
    }

    [HttpGet]
    [Route("{action}")]
    public async Task<ActionResult<List<ReservationsViewModel>>> GetAllReservationsForCurrentlyLoggedInUser()
    {
        var currentlyLoggedInUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        
        var allReservations = await _reservationsRepository.GetAllByUserIdAsync(currentlyLoggedInUser);

        var result = new List<ReservationsViewModel>();

        foreach (var reservation in allReservations)
        {
            var viewModel = reservation.MapToViewModel();
            result.Add(viewModel);
        }

        return View(result);
    }
    
    [HttpGet]
    [Route("{action}")]
    public async Task<ActionResult> CreateReservation()
    {
        var viewModel = new CreateReservationViewModel
        {
            AllLocations = new List<SelectListItem>(),
            AllCars = new List<SelectListItem>(),
            StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0),
            EndDate = DateTime.Today.AddDays(2)
        };

        await PopulateCreateReservationViewModelWithLocationsAndCars(viewModel);
        
        return View(viewModel);
    }

    [HttpPost]
    [Route("{action}")]
    public async Task<ActionResult> CreateReservation(CreateReservationViewModel createReservationViewModel)
    {
        if (!TryValidateModel(createReservationViewModel))
        {
            createReservationViewModel.AllCars = new List<SelectListItem>();
            createReservationViewModel.AllLocations = new List<SelectListItem>();
            await PopulateCreateReservationViewModelWithLocationsAndCars(createReservationViewModel);
            return View(createReservationViewModel);
        }
        
        var currentlyLoggedInUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;

        var daysOfRent = createReservationViewModel.EndDate.Date - createReservationViewModel.StartDate.Date;
        var car = await _carsRepository.GetCarByIdAsync(createReservationViewModel.CarId);
        var price = daysOfRent.Days * car.Price;
        
        await _reservationsRepository.CreateReservationAsync(currentlyLoggedInUser,
            createReservationViewModel.StartLocationId, createReservationViewModel.EndLocationId, createReservationViewModel.CarId,
            createReservationViewModel.StartDate, createReservationViewModel.EndDate, price > 0 ? price : car.Price);

        return RedirectToAction("GetAllReservationsForCurrentlyLoggedInUser");
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
        
        return RedirectToAction("GetAllReservationsForCurrentlyLoggedInUser");
    }

    private async Task PopulateCreateReservationViewModelWithLocationsAndCars(CreateReservationViewModel viewModel)
    {
        var allLocations = await _locationsRepository.GetAllLocationsAsync();
        foreach (var location in allLocations)
        {
            viewModel.AllLocations.Add( new SelectListItem(location.Country + ", " + location.City + ", " + location.Address, location.Id.ToString()));
        }

        var allCars = await _carsRepository.GetAllCars();
        foreach (var car in allCars)
        {
            viewModel.AllCars.Add(new SelectListItem(car.Name + " " + car.Model + ", " + car.Color + ", " + car.Price + "\u20ac" + "/per day", car.Id.ToString()));
        }
    }
}