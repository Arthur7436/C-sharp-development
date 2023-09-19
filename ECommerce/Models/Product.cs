using ECommerce.Interface.IProductOperations;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Product : IProduct
    {
        [ScaffoldColumn(false)]
        public string? Id { get; set; }
        [Required, StringLength(100), Display(Name = "Name")]
        public string? NameOfProduct { get; set; }
        [Required, StringLength(100), Display(Name = "Product Description"), DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        public override string ToString() //convert the product into readable string
        {
            return $"Product Id: {Id} \n" +
                $"Name of Product: {NameOfProduct} \n" +
                $"Description of Product: {Description}";
        }
    }
}
