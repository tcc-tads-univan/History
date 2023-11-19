using History.Api.Database.Entities;
using History.Api.Enum;

namespace History.Api.Repository
{
    public interface IHistoryRepository
    {
        Task SaveTrip(Trip trip);
        Task UpdateTripStatus(int scheduleId, string status);
        Task<Trip> GetTripByScheduleId(int scheduleId);
        Task<IEnumerable<Trip>> GetAllStudentTrips(int StudentId);
        Task<IEnumerable<Trip>> GetAllDriverTrips(int driverId);
    }
}
