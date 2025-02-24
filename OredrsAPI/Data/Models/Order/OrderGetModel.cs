using OredrsAPI.Data.Models.Extentions;
using OredrsAPI.Data.Models.Product;

namespace OredrsAPI.Data.Models.Order
{
    public class OrderGetModel : BaseEntry
    {
        public DateTime? Date { get; set; }
        public string Number { get; set; }
        public string Customer { get; set; }
        public List<ProductGetModel> Products { get; set; }
        public decimal Total { get; set; } = 0;
        public OrderGetModel() { }
        public OrderGetModel(OrderEntry order, List<ProductEntry> products)
        {
            Date = order.Date;
            Id = order.Id;
            Number = order.Number;
            Customer = order.Customer;
            Products = new List<ProductGetModel>();
            foreach (var item in products)
            {
                Products.Add(new ProductGetModel(item));
                Total += item.Price;
            }
        }
    }
}
