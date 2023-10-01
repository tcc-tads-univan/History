using History.Api.Database.Entities;
using History.Api.Enum;

namespace History.Api.Repository
{
    public interface IHistoryRepository
    {
        Task SaveTrip(Trip trip);
        Task UpdateTripStatus(int driverId, string status);
        Task<List<Trip>> GetAllTrips(int userId, UserType userType);
    }
}
