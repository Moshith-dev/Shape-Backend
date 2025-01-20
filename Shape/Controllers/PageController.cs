using Microsoft.AspNetCore.Mvc;
using Shape.DataBaseConnection;
using Dapper;
using Shape.Model;
using System.Data;


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
        public ActionResult<IEnumerable<PageContent>> GetContactUs()
        {
            IEnumerable<PageContent> List;

            using (IDbConnection connection = _dbConnection.GetSqlConnection())
            {
                connection.Open();
                // Use Dapper to query the database
                List = connection.Query<PageContent>("SELECT Id, Heading, Description FROM PageContent");
            }

            return Ok(List);
        }
    }
}