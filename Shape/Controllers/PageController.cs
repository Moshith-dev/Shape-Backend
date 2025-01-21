using Microsoft.AspNetCore.Mvc;
using Shape.DataBaseConnection;
using Dapper;
using Shape.Model;
using System.Data;
using System.Collections.Generic;


namespace Shape.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PageController : ControllerBase
    {
        private readonly DbConnection _dbConnection;

        public PageController(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PageContent>>> GetPageContent()
        {
            try
            {
                using (IDbConnection connection = _dbConnection.GetSqlConnection())
                {

                    var List = await connection.QueryAsync<PageContent>(
                        "GetPageContent",
                        commandType: CommandType.StoredProcedure
                        );
                    return Ok(List.ToList());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error Fetching PageContent", details = ex.Message });
            }
        }
    }
}