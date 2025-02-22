using OredrsAPI.Data.Models.Extentions;

namespace OredrsAPI.Data.Models.Product
{
    public class ProductGetModel : BaseEntry
    {
        public string Title { get; set; }
        public int? Amount { get; set; }
        public decimal Price { get; set; }
        public ProductGetModel() { }
        public ProductGetModel(ProductEntry product)
        {
            Title = product.Title;
            Id = product.Id;
            Amount = product.Amount;
            Price = product.Price;
        }
    }
}
