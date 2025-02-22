using OredrsAPI.Data.Models.Extentions;

namespace OredrsAPI.Data.Models.Order
{
    public class OrderEntry : BaseEntry
    {
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Number { get; set; }
        public string Customer { get; set; }
        public OrderEntry() { }
        public OrderEntry(OrderAddModel addModel)
        {
            Number = addModel.Number;
            Customer = addModel.Customer;
        }
    }
}
