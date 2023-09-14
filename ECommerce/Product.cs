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

        public override string ToString() // figure how to display the entire product object with it's properties
        {
            return $"Product Id: {Id} \n" +
                $"Name of Product: {NameOfProduct} \n" +
                $"Description of Product: {Description}";
        }
    }



}
