using OredrsAPI.Data.Models.Order;

namespace OredrsAPI.Services.Order
{
    public interface IOrderService
    {
        public Task<OrderGetModel> GetOrderByIdAsync(int id);
        public Task<OrderGetModel> AddOrderAsync(OrderAddModel order);
    }
}
