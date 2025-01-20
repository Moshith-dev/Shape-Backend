using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Shape.DataBaseConnection;
using Shape.Model;
using System.Collections.Generic;
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
        public ActionResult<IEnumerable<ContactUs>> GetContactUs()
        {
            IEnumerable<ContactUs> List;

            using (IDbConnection connection = _dbConnection.GetSqlConnection())
            {
                connection.Open();
                // Use Dapper to query the database
                List = connection.Query<ContactUs>("SELECT Id, Address, Timing, Contact FROM ContactUs");
            }

            return Ok(List);
        }
    }
}