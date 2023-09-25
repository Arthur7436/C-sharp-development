using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route("api/Ecommerce")]
    public class ECommerceController : ControllerBase
    {
        private readonly ILogger<ECommerceController> _logger;

        public ECommerceController(ILogger<ECommerceController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetProduct")]
        public IActionResult Get()
        {
            string pwd = Environment.GetEnvironmentVariable("SQL_PASSWORD", EnvironmentVariableTarget.Machine)!; //used SETX command to store SQL_PASSWORD into local machine so that credentials are not hard-coded

            //Attempt to connect console application to server database

            //variable declaration
            string connectionString = null!;
            SqlConnection cnn;
            connectionString = $"Data Source=AUL0953;Initial Catalog=ProductDB;User ID=sa;Password={pwd}";

            //assign connection
            cnn = new SqlConnection(connectionString);

            //create sql commands to be able to read from db
            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";
            sql = "Select Identify,Id,NameOfProduct,Description from dbo.Product";

            //Open connection
            cnn.Open();
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            //create a list to store the output
            List<Product> products = new List<Product>();

            while (dataReader.Read())
            {
                Product product = new Product();
                product.Id = (string)dataReader["Id"];
                product.NameOfProduct = (string)dataReader["NameOfProduct"];
                product.Description = (string)dataReader["Description"];
                products.Add(product);
            }

            dataReader.Close();
            command.Dispose();
            cnn.Close();

            //serialize the list into json format
            //string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            string json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return Ok(json);

        }

        [HttpPost]
        [Route("/post")]
        public IActionResult Post([FromBody] Product product) //deserialize incoming request and map it against Product object 
        {

            //set sql variables
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";

            string pwd = Environment.GetEnvironmentVariable("SQL_PASSWORD", EnvironmentVariableTarget.Machine)!;
            string connectionString = null!;
            SqlConnection cnn;
            connectionString = $"Data Source=AUL0953;Initial Catalog=ProductDB;User ID=sa;Password={pwd}";
            cnn = new SqlConnection(connectionString);

            //push data into sql db
            sql = $"Insert into dbo.Product (Identify,Id,NameOfProduct,Description) values('" + $"{100}" + "', '" + $"{product.Id}" + "', '" + $"{product.NameOfProduct}" + "' , '" + $"{product.Description}" + "')";
            command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = new SqlCommand(sql, cnn);

            cnn.Open();
            adapter.InsertCommand.ExecuteNonQuery();

            command.Dispose();
            cnn.Close();

            //validate logic
            if (product.Id == null)
            {
                return BadRequest("Product Id is empty!");
            }
            if (product.NameOfProduct == null)
            {
                return BadRequest("Product name is empty!");
            }
            if (product.Description == null)
            {
                return BadRequest("Product description is empty!");
            }

            return Ok(product);
        }
    }

}