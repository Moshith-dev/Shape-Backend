using Dapper;
using Shape.DataBaseConnection;
using Shape.Models;
using System.Data;


namespace Shape.Repositories
{
    public class PageRepository : IPageRepository
    {
        private readonly DbConnection _dbConnection;
        public PageRepository(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<IEnumerable<ContactUs>> GetContactUsAsync()
        {
            using (IDbConnection connection = _dbConnection.GetSqlConnection())
            {
                return await connection.QueryAsync<ContactUs>("GetContact", commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<Icons>> GetIconsAsync()
        {
            using (IDbConnection connection = _dbConnection.GetSqlConnection())
            {

                return await connection.QueryAsync<Icons>("GetIcon", commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<PageContent>> GetPageContentAsync()
        {
            using (IDbConnection connection = _dbConnection.GetSqlConnection())
            {
                return await connection.QueryAsync<PageContent>("GetPageContent", commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            using (IDbConnection connection = _dbConnection.GetSqlConnection())
            {
                return await connection.QueryAsync<Employee>("GetEmployee", commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<MenuTable>> GetMenuAsync()
        {
            using (IDbConnection connection = _dbConnection.GetSqlConnection())
            {
                return await connection.QueryAsync<MenuTable>("GetMenu", commandType: CommandType.StoredProcedure);
            }
        }
    }
}
