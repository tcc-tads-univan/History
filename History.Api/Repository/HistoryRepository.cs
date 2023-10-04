using Dapper;
using History.Api.Database.Entities;
using History.Api.Database.Interfaces;

namespace History.Api.Repository
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly IDbConnectionFactory _dbConnection;
        public HistoryRepository(IDbConnectionFactory dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Trip>> GetAllDriverTrips(int driverId)
        {
            using var connection = await _dbConnection.CreateConnection();
            return await connection.QueryAsync<Trip>(
                @"SELECT Id, StudentId, StudentName, DriverId, DriverName, InitialDestination, FinalDestination, Price, Date, Status 
                FROM Customers WHERE DriverId = @DriverId", new { DriverId = driverId });
        }

        public async Task<IEnumerable<Trip>> GetAllStudentTrips(int studentId)
        {
            using var connection = await _dbConnection.CreateConnection();
            return await connection.QueryAsync<Trip>(
                @"SELECT Id, StudentId, StudentName, DriverId, DriverName, InitialDestination, FinalDestination, Price, Date, Status 
                FROM Customers WHERE StudentId = @StudentId", new { StudentId = studentId });
        }

        public async Task SaveTrip(Trip trip)
        {
            using var connection = await _dbConnection.CreateConnection();
            await connection.ExecuteAsync(
                @"INSERT INTO Trip(StudentId, StudentName, DriverId, DriverName, InitialDestination, FinalDestination, Price, Date, Status)
                VALUES(@StudentId, @StudentName, @DriverId, @DriverName, @InitialDestination, @FinalDestination, @Price, @Date, @Status)",
                trip);
        }

        public async Task UpdateTripStatus(int driverId, int studentId, string status)
        {
            using var connection = await _dbConnection.CreateConnection();
            await connection.ExecuteAsync(
                @"UPDATE Trip SET Status = @Status WHERE StudentId = @StudentId AND DriverId = @DriverId",
                new
                {
                    StudentId = studentId,
                    DriverId = driverId,
                    Status = status
                });
        }
    }
}
