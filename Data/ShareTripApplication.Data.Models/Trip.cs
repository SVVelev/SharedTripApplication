namespace ShareTripApplication.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using ShareTripApplication.Data.Common.Models;

    public class Trip : BaseDeletableModel<string>
    {
        public Trip()
        {
            this.UserTrip = new HashSet<UserTrips>();
        }

        [Required]
        public string StartPoint { get; set; }

        [Required]
        public string EndPoint { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public int Seats { get; set; }

        [Required]
        [MaxLength(80)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public virtual ICollection<UserTrips> UserTrip { get; set; }
    }
}
