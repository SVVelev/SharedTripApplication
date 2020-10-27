namespace ShareTripApplication.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using ShareTripApplication.Data.Common.Models;

    public class UserTrips
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string TripId { get; set; }

        public Trip Trip { get; set; }
    }
}
