using Dapper;
using Microsoft.AspNetCore.Mvc;
using Shape.DataBaseConnection;
using Shape.Model;
using System.Data;

namespace Shape.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactUsController : ControllerBase
    {
        private readonly DbConnection _dbConnection;

        public ContactUsController(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactUs>>> GetContactUs()
        {
            try
            {
                using (var connection = _dbConnection.GetSqlConnection())
                {
                   
                    var contactUs = await connection.QueryAsync<ContactUs>(
                        "GetContact",
                        commandType: CommandType.StoredProcedure
                     );
                    return Ok(contactUs.ToList());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {message = "Error Fetching ContactUs", details = ex.Message});
            }
        }
    }
}