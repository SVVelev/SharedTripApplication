namespace ShareTripApplication.Web.ViewModels.Trips.Create
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using ShareTripApplication.Data.Models;
    using ShareTripApplication.Services.Mapping;

    public class CreateTripInputModel : IMapTo<Trip>
    {
        [Required]
        [Display(Name = "Start Point")]
        public string StartPoint { get; set; }

        [Required]
        [Display(Name = "End Point")]
        public string EndPoint { get; set; }

        [Required]
        [Display(Name = "Departure Time")]
        public DateTime DepartureTime { get; set; }

        [Required]
        public int Seats { get; set; }

        [Required]
        [StringLength(80, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string Description { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }
    }
}
