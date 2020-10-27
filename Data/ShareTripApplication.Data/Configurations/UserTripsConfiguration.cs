namespace ShareTripApplication.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ShareTripApplication.Data.Models;

    public class UserTripsConfiguration : IEntityTypeConfiguration<UserTrips>
    {
        public void Configure(EntityTypeBuilder<UserTrips> builder)
        {
            builder.HasKey(x => new { x.UserId, x.TripId });
        }
    }
}
