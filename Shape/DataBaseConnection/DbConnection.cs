using Microsoft.Data.SqlClient;

namespace Shape.DataBaseConnection
{
    public class DbConnection
    {
        private readonly IConfiguration configuration;
        private readonly string _connectionString;
        public DbConnection(IConfiguration configuration)
        {
            this.configuration = configuration;
            _connectionString = configuration.GetConnectionString("Database");
        }
        public SqlConnection GetSqlConnection() => new SqlConnection(_connectionString);

    }
}
