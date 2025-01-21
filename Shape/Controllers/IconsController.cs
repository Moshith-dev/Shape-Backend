using Dapper;
using Microsoft.AspNetCore.Mvc;
using Shape.DataBaseConnection;
using Shape.Model;
using System.Data;

namespace Shape.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IconsController : ControllerBase
    {
        private readonly DbConnection _dbConnection;

        public IconsController(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Icons>>> GetIcon()
        {

            try
            {
                using (IDbConnection connection = _dbConnection.GetSqlConnection())
                {

                    // Use Dapper to query the database
                    var List = await connection.QueryAsync<Icons>(
                        "GetIcon",
                        commandType: CommandType.StoredProcedure
                        );
                    return Ok(List.ToList());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error Fetching Icons", details = ex.Message });


            }
        }
    }
}