using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShareTripApplication.Services.Data.Users
{
   public interface IUserService
    {
        Task<string> EditAsync(string phoneNumber, string imagePath, string userId);

        Task<string> DeleteAsync(string id);

        IEnumerable<T> GetUsersForCurrentTrip<T>(string tripId);
    }
}
