using Dapper;
using History.Api.Database.Entities;
using History.Api.Database.Interfaces;
using History.Api.Enum;

namespace History.Api.Repository
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly IDbConnectionFactory _dbConnection;
        public HistoryRepository(IDbConnectionFactory dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public Task<List<Trip>> GetAllTrips(int userId, UserType userType)
        {
            throw new NotImplementedException();
        }

        public async Task SaveTrip(Trip trip)
        {
            using var connection = await _dbConnection.CreateConnection();
            await connection.ExecuteAsync(
                @"INSERT INTO Trip()
                VALUES()",
                trip);
        }

        public Task UpdateTripStatus(int driverId, string status)
        {
            throw new NotImplementedException();
        }
    }
}
