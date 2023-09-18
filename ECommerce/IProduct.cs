namespace ECommerce.Interface.IProductOperations
{
    public interface IProduct
    {
        string Id { get; set; }
        public string NameOfProduct { get; set; }
        public string Description { get; set; }
        string ToString();

    }
}
