namespace ECommerce.Product
{
    public class Product
    {
        public string Id { get; set; }
        public string NameOfProduct { get; set; }
        public string Description { get; set; }

        public override string ToString() // figure how to display the entire product object with it's properties
        {
            return $"Product Id THIS IS FROM THE PRODUCT CLASS!: {Id} \n" +
                $"Name of Product THIS IS FROM THE PRODUCT CLASS!: {NameOfProduct} \n" +
                $"Description of Product THIS IS FROM THE PRODUCT CLASS!: {Description}";
        }
    }



}
