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
    public class MenuController : ControllerBase
    {
        private readonly DbConnection _dbConnection;

        public MenuController(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MenuTable>> GetContactUs()
        {
            IEnumerable<MenuTable> Menu;

            using (IDbConnection connection = _dbConnection.GetSqlConnection())
            {
                connection.Open();
                // Use Dapper to query the database
                Menu = connection.Query<MenuTable>("SELECT Id, Menu, OrderNo, ParentId, IsHeader, IsFooter FROM Menu");
            }

            return Ok(Menu);
           
        }
    }
}