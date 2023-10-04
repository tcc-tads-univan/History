using History.Api.Contracts;
using History.Api.Database.Entities;
using History.Api.Enum;
using History.Api.Mapping;
using History.Api.Repository;

namespace History.Api.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IHistoryRepository _historyRepository;

        public HistoryService(IHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        public async Task<IEnumerable<TripResponse>> GetUserHistory(int userId, UserType userType)
        {
            var trips = userType.Equals(UserType.STUDENT) ? await _historyRepository.GetAllStudentTrips(userId) : await _historyRepository.GetAllDriverTrips(userId);
            return trips.Select(t => t.ToTripResponse());
        }

        public Task SaveTrip(Trip trip)
        {
            throw new NotImplementedException();
        }
    }
}
