using ECommerce.Interface.IProduct;

namespace ECommerce.Product
{
    public class Product : IProduct
    {
        public string GetId() //returns a random id for the product
        {
            return Guid.NewGuid().ToString("N");

        }

        public string GetNameOfProduct()
        {
            return "Test";
        }

        public string GetDescriptionOfProduct()
        {
            return "Test";
        }
    }
}
