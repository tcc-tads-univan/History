using System.Data;

namespace History.Api.Database.Interfaces
{
    public interface IDbConnectionFactory
    {
        Task<IDbConnection> CreateConnection();
    }
}
