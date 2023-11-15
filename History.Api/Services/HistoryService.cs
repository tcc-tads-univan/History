﻿using History.Api.Contracts;
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

        public Task CompleteTrip(int studentId, int driverId)
        {
            return _historyRepository.UpdateTripStatus(driverId, studentId, nameof(TripStatus.COMPLETED));
        }

        public async Task<TripResponse> GetHistory(int scheduleId)
        {
            var trip = await _historyRepository.GetTripByScheduleId(scheduleId);
            return trip.ToTripResponse();
        }

        public async Task<IEnumerable<TripResponse>> GetUserHistory(int userId, UserType userType)
        {
            var trips = userType.Equals(UserType.STUDENT) ? await _historyRepository.GetAllStudentTrips(userId) : await _historyRepository.GetAllDriverTrips(userId);
            return trips.Select(t => t.ToTripResponse());
        }

        public Task SaveTrip(Trip trip)
        {
            return _historyRepository.SaveTrip(trip);
        }
    }
}
