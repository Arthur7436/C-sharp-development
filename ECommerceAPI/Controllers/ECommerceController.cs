using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ECommerceController : ControllerBase
    {
        private readonly ILogger<ECommerceController> _logger;

        public ECommerceController(ILogger<ECommerceController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetECommerce")]
        public IEnumerable<Product> Get()
        {
            string pwd = Environment.GetEnvironmentVariable("SQL_PASSWORD", EnvironmentVariableTarget.Machine)!; //used SETX command to store SQL_PASSWORD into local machine so that credentials are not hard-coded

            _logger.LogInformation("Storage of password in variable was successful...");

            //Attempt to connect console application to server database

            //variable declaration
            string connectionString = null!;
            SqlConnection cnn;
            connectionString = $"Data Source=AUL0953;Initial Catalog=ProductDB;User ID=sa;Password={pwd}";

            cnn = new SqlConnection(connectionString);

            try
            {
                cnn.Open();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex.Message}");
            }

        }
    }
}