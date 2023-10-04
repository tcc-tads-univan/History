using History.Api.Contracts;
using History.Api.Database.Entities;
using History.Api.Enum;

namespace History.Api.Services
{
    public interface IHistoryService
    {
        Task<IEnumerable<TripResponse>> GetUserHistory(int userId, UserType userType);
        Task SaveTrip(Trip trip);
    }
}
