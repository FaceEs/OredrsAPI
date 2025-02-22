using OredrsAPI.Data.Models.Product;

namespace OredrsAPI.Data.Models.Order
{
    public class OrderAddModel
    {
        public string Number { get; set; }
        public string Customer { get; set; }
        public List<ProductAddModel> Products { get; set; }
        public OrderAddModel() { 
        
        }
    }
}
