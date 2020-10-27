namespace ShareTripApplication.Services.Data.Trips
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using ShareTripApplication.Data.Models;

    public interface ITripService
    {
        Task<string> CreateAsync(string startPoint, string endPoint, DateTime departureTime, int seats, string description, string imagePath = null);

        Task<string> AddUserTrip(string userId, string tripId);

        IEnumerable<T> GetAllTrips<T>(ApplicationUser user);

        T GetTripById<T>(string id);

        Task<string> UpdateTripSeats(string tripId);
    }
}
