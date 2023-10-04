using History.Api.BackgroundTask.Events;
using History.Api.Database.Entities;
using History.Api.Enum;

namespace History.Api.Mapping
{
    public static class EventToDomainMapper
    {
        public static Trip ToTrip(this SaveTripEvent eventMessage)
        {
            return new Trip()
            {
                DriverId = eventMessage.DriverId,
                DriverName = eventMessage.DriverName,
                StudentId = eventMessage.StudentId,
                StudentName = eventMessage.StudentName,
                FinalDestination = eventMessage.FinalDestination,
                InitialDestination = eventMessage.InitialDestination,
                Price = eventMessage.Price,
                Date = DateTime.Now,
                Status = nameof(TripStatus.TRAVELING)
            };
        }
    }
}
