using OredrsAPI.Data.Models.Extentions;
using OredrsAPI.Data.Models.Order;
using OredrsAPI.Extentions.Product;

namespace OredrsAPI.Data.Models.Product
{
    public class ProductEntry : BaseEntry
    {
        public string Title { get; set; }
        public int? Amount { get; set; }
        public decimal Price { get; set; }
        public OrderEntry Order { get; set; }
        public ProductEntry() { }
        public ProductEntry(ProductAddModel addModel, OrderEntry order) {
            Title = addModel.Title;
            Amount = addModel.Amount;
            Price = addModel.Price;
            Order = order;
            this.Validate();
        }
    }
}
