namespace ShareTripApplication.Web.ViewModels.Users.AllTrips
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using ShareTripApplication.Data.Models;
    using ShareTripApplication.Services.Mapping;

    public class UsersTripViewModel : IMapFrom<ApplicationUser>
    {
        public string UserName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
