using History.Api.Database.Entities;
using History.Api.Enum;

namespace History.Api.Repository
{
    public interface IHistoryRepository
    {
        Task SaveTrip(Trip trip);
        Task UpdateTripStatus(int driverId, int studentId, string status);
        Task<IEnumerable<Trip>> GetAllStudentTrips(int StudentId);
        Task<IEnumerable<Trip>> GetAllDriverTrips(int driverId);
    }
}
