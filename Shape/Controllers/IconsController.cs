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
        public ActionResult<IEnumerable<Icons>> GetContactUs()
        {
            IEnumerable<Icons> List;

            using (IDbConnection connection = _dbConnection.GetSqlConnection())
            {
                connection.Open();
                // Use Dapper to query the database
                List = connection.Query<Icons>("SELECT Id, IconUrl, IconAlt FROM Icons");
            }

            return Ok(List);
        }
    }
}