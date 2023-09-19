using Ecommerce.Interfaces.IProductOperations;

namespace ECommerce.Models
{
    public class Product : IProduct
    {
        public string? Id { get; set; }
        public string? NameOfProduct { get; set; }
        public string? Description { get; set; }
        public override string ToString() //convert the product into readable string
        {
            return $"Product Id: {Id} \n" +
                $"Name of Product: {NameOfProduct} \n" +
                $"Description of Product: {Description}";
        }
    }
}
