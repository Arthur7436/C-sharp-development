namespace ECommerce.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("ECommerce")
        {
        }
    }
}
