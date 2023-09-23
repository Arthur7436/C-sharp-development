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
                product.Id = dataReader.ToString();
                product.NameOfProduct = dataReader.ToString();
                product.Description = dataReader.ToString();

                products.Add(product);
            }



            //serialize the list into json format
            //products = JsonConvert.SerializeObject(products, Formatting.Indented);

            return products;

        }
    }
}