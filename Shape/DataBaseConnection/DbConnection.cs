using Microsoft.Data.SqlClient;

namespace Shape.DataBaseConnection
{
    public class DbConnection(string connectionString)
    {
        private readonly string _connectionString = connectionString;

        public DbConnection(IConfiguration configuration) : this(configuration.GetConnectionString("Database") ?? throw new ArgumentNullException(nameof(configuration), "Database connection string cannot be null"))
        {
        }

        public SqlConnection GetSqlConnection() => new(_connectionString);
    }
}