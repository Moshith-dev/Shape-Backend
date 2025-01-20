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
    public class EmployeeController : ControllerBase
    {
        private readonly DbConnection _dbConnection;

        public EmployeeController(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetContactUs()
        {

            IEnumerable<Employee> employees;

            using (IDbConnection connection = _dbConnection.GetSqlConnection())
            {
                connection.Open();
                // Use Dapper to query the database
                employees = connection.Query<Employee> ("SELECT Id, EmpName, EmpRole, EmpDescription FROM Employee");
            }

            return Ok(employees);

            
        }
    }
}