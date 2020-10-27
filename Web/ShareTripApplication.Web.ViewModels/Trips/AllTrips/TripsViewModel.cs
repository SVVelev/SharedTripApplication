using ShareTripApplication.Data.Models;
using ShareTripApplication.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareTripApplication.Web.ViewModels.Trips.AllTrips
{
    public class TripsViewModel : IMapFrom<Trip>
    {
        public string Id { get; set; }

        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; set; }

        public int Seats { get; set; }
    }
}
