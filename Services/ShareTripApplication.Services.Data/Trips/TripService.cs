namespace ShareTripApplication.Services.Data.Trips
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ShareTripApplication.Data.Common.Repositories;
    using ShareTripApplication.Data.Models;
    using ShareTripApplication.Services.Mapping;
    using ShareTripApplication.Web.ViewModels.Trips.TripId;

    public class TripService : ITripService
    {
        private readonly IDeletableEntityRepository<Trip> tripRepository;
        private readonly IRepository<UserTrips> userTripsRepository;

        public TripService(IDeletableEntityRepository<Trip> tripRepository, IRepository<UserTrips> userTripsRepository)
        {
            this.tripRepository = tripRepository;
            this.userTripsRepository = userTripsRepository;
        }

        public async Task<string> CreateAsync(string startPoint, string endPoint, DateTime departureTime, int seats, string description, string imagePath = null)
        {
            var trip = new Trip
            {
                Id = Guid.NewGuid().ToString(),
                StartPoint = startPoint,
                EndPoint = endPoint,
                DepartureTime = departureTime,
                Seats = seats,
                Description = description,
                ImagePath = imagePath,
            };

            await this.tripRepository.AddAsync(trip);
            await this.tripRepository.SaveChangesAsync();
            return trip.Id;
        }

        public async Task<string> AddUserTrip(string userId, string tripId)
        {
            var currentTrip = this.tripRepository
                .All()
                .Where(x => x.Id == tripId)
                .FirstOrDefault();

            var updatedTripId = this.UpdateTripSeats(currentTrip.Id);

            var userTrip = new UserTrips
            {
                UserId = userId,
                TripId = tripId,
            };
            await this.userTripsRepository.AddAsync(userTrip);
            await this.userTripsRepository.SaveChangesAsync();

            return currentTrip.Id;
        }

        public IEnumerable<T> GetAllTrips<T>(ApplicationUser user)
        {
            IQueryable<Trip> query = Enumerable.Empty<Trip>().AsQueryable();

            if (user != null)
            {
                query =
                this.tripRepository
                .All()
                .OrderByDescending(x => x.CreatedOn);
            }

            return query.To<T>().ToList();
        }

        public T GetTripById<T>(string id)
        {
            var trip = this.tripRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return trip;
        }

        public async Task<string> UpdateTripSeats(string tripId)
        {
            var currentTrip = this.tripRepository
                .All()
                .Where(x => x.Id == tripId)
                .FirstOrDefault();

            currentTrip.Seats -= 1;
            this.tripRepository.Update(currentTrip);
            await this.tripRepository.SaveChangesAsync();

            return currentTrip.Id;
        }

    }
}
