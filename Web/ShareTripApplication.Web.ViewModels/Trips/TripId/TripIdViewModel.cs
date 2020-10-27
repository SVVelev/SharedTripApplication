using ShareTripApplication.Data.Models;
using ShareTripApplication.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareTripApplication.Web.ViewModels.Trips.TripId
{
    public class TripIdViewModel : IMapFrom<Trip>
    {
        public string Id { get; set; }

        public int Seats { get; set; }
    }
}
