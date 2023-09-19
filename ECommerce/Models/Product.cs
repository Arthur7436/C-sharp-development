using Ecommerce.Interfaces.IProductOperations;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Product : IProduct
    {
        [ScaffoldColumn(false)]
        public string? Id { get; set; }
        [Required, StringLength(50), Display(Name = "Name")]
        public string? NameOfProduct { get; set; }
        [Required, StringLength(50), Display(Name = "Description")]
        public string? Description { get; set; }
        public override string ToString() //convert the product into readable string
        {
            return $"Product Id: {Id} \n" +
                $"Name of Product: {NameOfProduct} \n" +
                $"Description of Product: {Description}";
        }
    }
}
