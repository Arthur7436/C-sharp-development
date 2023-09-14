namespace ECommerce.Product
{
    //public class Product : IProduct
    //{
    //    public string GetId() //returns a random id for the product
    //    {
    //        return Guid.NewGuid().ToString("N");

    //    }

    //    public string GetNameOfProduct()
    //    {

    //        return "Test";
    //    }

    //    public string GetDescriptionOfProduct()
    //    {
    //        return "Test";
    //    }
    //}

    public class Product
    {
        public string Id { get; set; }
        public string NameOfProduct { get; set; }
        public string Description { get; set; }
    }



}
