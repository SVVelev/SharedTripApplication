namespace ShareTripApplication.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ShareTripApplication.Data.Models;
    using ShareTripApplication.Services.Data.Trips;
    using ShareTripApplication.Services.Mapping;
    using ShareTripApplication.Web.ViewModels.Error;
    using ShareTripApplication.Web.ViewModels.Trips.AllTrips;
    using ShareTripApplication.Web.ViewModels.Trips.Create;
    using ShareTripApplication.Web.ViewModels.Trips.Details;
    using ShareTripApplication.Web.ViewModels.Trips.TripId;

    [Authorize]
    public class TripController : BaseController
    {
        private readonly ITripService tripService;
        private readonly UserManager<ApplicationUser> userManager;

        public TripController(ITripService tripService, UserManager<ApplicationUser> userManager)
        {
            this.tripService = tripService;
            this.userManager = userManager;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateTripInputModel();

            return this.View(viewModel);
        }

        public IActionResult Details(string id)
        {
            var viewModel = this.tripService.GetTripById<TripDetailsViewModel>(id);

            return this.View(viewModel);
        }

        public IActionResult AddUserToTrip(string id)
        {
            var userId = this.userManager.GetUserId(this.User);
            var trip = this.tripService.GetTripById<TripIdViewModel>(id);

            if (trip.Seats == 0)
            {
                string errorMessage = "There is no free seat";
                return this.RedirectToAction("Error", "Home", new { message = errorMessage });
            }

            var tripId = this.tripService.AddUserTrip(userId, trip.Id);

            return this.RedirectToAction(nameof(this.AllTrips));
        }

        public IActionResult UserLeaveTrip(string id)
        {
            var userId = this.userManager.GetUserId(this.User);
            var trip = this.tripService.GetTripById<TripIdViewModel>(id);

            this.tripService.UserLeaveTrip(userId, trip.Id);

            return this.RedirectToAction(nameof(this.AllTrips));
        }

        public IActionResult AllTrips()
        {
            var viewModel = new AllTripsViewModel
            {
                Trips = this.tripService.GetAllTrips<TripsViewModel>(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTripInputModel input)
        {
            var trip = AutoMapperConfig.MapperInstance.Map<Trip>(input);

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var tripId = await this.tripService.CreateAsync(input.StartPoint, input.EndPoint, input.DepartureTime, input.Seats, input.Description, input.ImagePath);

            return this.RedirectToAction(nameof(this.Details), new { id = tripId });
        }
    }
}
