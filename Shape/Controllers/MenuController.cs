using Dapper;
using Microsoft.AspNetCore.Mvc;
using Shape.DataBaseConnection;
using Shape.Model;
using System.Data;

namespace Shape.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly DbConnection _dbConnection;

        public MenuController(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuTable>>> GetMenu()
        {
            try
            {
                using (IDbConnection connection = _dbConnection.GetSqlConnection())
                {
                    // Use Dapper to query the database
                    var List = await connection.QueryAsync<MenuTable>(
                        "GetMenu",
                        commandType: CommandType.StoredProcedure
                        );
                    return Ok(List.ToList());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error Fetching Menu", details = ex.Message });

            }
        }
    }
}