using System;
using System.Collections.Generic;
using System.Text;

namespace ShareTripApplication.Web.ViewModels.Trips.AllTrips
{
    public class AllTripsViewModel
    {
        public IEnumerable<TripsViewModel> Trips { get; set; }
    }
}
