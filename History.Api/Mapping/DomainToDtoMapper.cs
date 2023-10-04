using History.Api.Contracts;
using History.Api.Database.Entities;

namespace History.Api.Mapping
{
    public static class DomainToDtoMapper
    {
        public static TripResponse ToTripResponse(this Trip trip)
        {
            return new TripResponse()
            {
                Id = trip.Id,
                Date = trip.Date,
                DriverId = trip.DriverId,
                DriverName = trip.DriverName,
                FinalDestination = trip.FinalDestination,
                InitialDestination = trip.InitialDestination,
                Price = trip.Price,
                Status = trip.Status,
                StudentId = trip.StudentId,
                StudentName = trip.StudentName
            };
        }
    }
}
