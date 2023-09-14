using ECommerce.Interface.IProduct;

namespace ECommerce.Product
{
    public class Product : IProduct
    {
        public int GetId()
        {
            Random random = new Random();

            const int maxValue = 999;
            int number = int.Parse(random.Next(maxValue + 1).ToString("D3"));
            return number;
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
