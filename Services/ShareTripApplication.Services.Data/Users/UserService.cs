using Microsoft.AspNetCore.Identity;
using ShareTripApplication.Data.Common.Repositories;
using ShareTripApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareTripApplication.Services.Data.Users
{
    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(IDeletableEntityRepository<ApplicationUser> userRepository, UserManager<ApplicationUser> userManager)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
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
    }
}
