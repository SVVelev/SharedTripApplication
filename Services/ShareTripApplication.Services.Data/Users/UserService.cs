namespace ShareTripApplication.Services.Data.Users
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using ShareTripApplication.Data.Common.Repositories;
    using ShareTripApplication.Data.Models;
    using ShareTripApplication.Services.Mapping;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository<UserTrips> userTripsRepository;

        public UserService(
            IDeletableEntityRepository<ApplicationUser> userRepository,
            UserManager<ApplicationUser> userManager,
            IRepository<UserTrips> userTripsRepository)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
            this.userTripsRepository = userTripsRepository;
        }

        public async Task<string> EditAsync(string phoneNumber, string imagePath, string userId)
        {
            var currentUser = this.userRepository
                .All()
                .Where(x => x.Id == userId)
                .FirstOrDefault();

            currentUser.PhoneNumber = phoneNumber;
            currentUser.ImagePath = imagePath;

            this.userRepository.Update(currentUser);
            await this.userRepository.SaveChangesAsync();

            return currentUser.Id;
        }

        public async Task<string> DeleteAsync(string id)
        {
            var user = this.userRepository
                .All()
                .FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                throw new ArgumentNullException($"User with {id} does not exist!");
            }

            this.userRepository.Delete(user);
            await this.userRepository.SaveChangesAsync();

            return user.Id;
        }

        public IEnumerable<T> GetUsersForCurrentTrip<T>(string tripId)
        {
            IQueryable<ApplicationUser> query = Enumerable.Empty<ApplicationUser>().AsQueryable();

            var currentUserTrips = this.userTripsRepository
                .All()
                .Where(x => x.TripId == tripId)
                .ToList();

            query = this.userRepository
           .All()
           .Where(x => currentUserTrips.Select(y => y.UserId).Contains(x.Id))
           .OrderByDescending(x => x.CreatedOn);

            return query.To<T>().ToList();
        }
    }
}
