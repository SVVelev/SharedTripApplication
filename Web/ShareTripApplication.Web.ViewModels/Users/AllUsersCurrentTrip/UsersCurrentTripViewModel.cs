using System;
using System.Collections.Generic;
using System.Text;

namespace ShareTripApplication.Web.ViewModels.Users.AllTrips
{
   public class UsersCurrentTripViewModel
    {
        public IEnumerable<UsersTripViewModel> Users { get; set; }
    }
}
