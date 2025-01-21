using Dapper;
using Microsoft.AspNetCore.Mvc;
using Shape.DataBaseConnection;
using Shape.Model;
using System.Data;

namespace Shape.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly DbConnection _dbConnection;

        public EmployeeController(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {

            try
            {
                using (var connection = _dbConnection.GetSqlConnection())
                {
                    var List = await connection.QueryAsync<Employee>(
                        "GetEmployee",
                        commandType: CommandType.StoredProcedure
                    );
                    return Ok(List.ToList());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error Fetching Employee", details = ex.Message });

            }
        }
    }
}