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
                @"SELECT Id, StudentId, StudentName, DriverId, DriverName, InitialDestination, FinalDestination, Price, Date, Status, ScheduleId 
                FROM Trips WHERE DriverId = @DriverId", new { DriverId = driverId });
        }
        
        public async Task<Trip> GetTripByScheduleId(int scheduleId)
        {
            using var connection = await _dbConnection.CreateConnection();
            return await connection.QueryFirstAsync<Trip>(
                @"SELECT Id, StudentId, StudentName, DriverId, DriverName, InitialDestination, FinalDestination, Price, Date, Status, ScheduleId
                FROM Trips WHERE ScheduleId = @ScheduleId", new { ScheduleId = scheduleId });
        }

        public async Task<IEnumerable<Trip>> GetAllStudentTrips(int studentId)
        {
            using var connection = await _dbConnection.CreateConnection();
            return await connection.QueryAsync<Trip>(
                @"SELECT Id, StudentId, StudentName, DriverId, DriverName, InitialDestination, FinalDestination, Price, Date, Status, ScheduleId 
                FROM Trips WHERE StudentId = @StudentId", new { StudentId = studentId });
        }

        public async Task SaveTrip(Trip trip)
        {
            using var connection = await _dbConnection.CreateConnection();
            await connection.ExecuteAsync(
                @"INSERT INTO Trips(StudentId, StudentName, DriverId, DriverName, InitialDestination, FinalDestination, Price, Date, Status, ScheduleId)
                VALUES(@StudentId, @StudentName, @DriverId, @DriverName, @InitialDestination, @FinalDestination, @Price, @Date, @Status, @ScheduleId)",
                trip);
        }

        public async Task UpdateTripStatus(int driverId, int studentId, string status)
        {
            using var connection = await _dbConnection.CreateConnection();
            await connection.ExecuteAsync(
                @"UPDATE Trips SET Status = @Status WHERE StudentId = @StudentId AND DriverId = @DriverId AND Status = 'TRAVELING'",
                new
                {
                    StudentId = studentId,
                    DriverId = driverId,
                    Status = status
                });
        }
    }
}
