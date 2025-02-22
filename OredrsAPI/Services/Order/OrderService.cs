using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OredrsAPI.Data;
using OredrsAPI.Data.Models.Order;
using OredrsAPI.Data.Models.Product;
using OredrsAPI.Extentions.Exceptions;

namespace OredrsAPI.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<OrderService> _logger;
        public OrderService(ApplicationDbContext context, ILogger<OrderService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<OrderGetModel> AddOrderAsync(OrderAddModel order)
        {
            try
            {
                OrderEntry newOrder = new OrderEntry(order);
                await _context.AddAsync(newOrder);
                foreach (var item in order.Products)
                {
                    ProductEntry newProduct = new ProductEntry(item, newOrder);
                    await _context.AddAsync(newProduct);
                }
                var test = await _context.SaveChangesAsync();
                var products = await _context.Products.Include(p=>p.Order).Where(p => p.Order.Id == newOrder.Id).ToListAsync();
                OrderGetModel orderGetModel = new OrderGetModel(newOrder,products);
                return orderGetModel;
            } catch (Exception ex)
            {
                _logger.LogError($"Error while adding order. {ex.Message}");
                throw;
            }
        }

        public async Task<OrderGetModel> GetOrderByIdAsync(int id)
        {
            try
            {
                OrderEntry order = await _context.Orders.FirstOrDefaultAsync(order => order.Id == id);
                if (order == null)
                {
                    _logger.LogWarning($"Order with id {id} not found");
                    throw new DbException($"Не найден заказ с идентификатором {id}");
                }
                var products = await _context.Products.Include(p => p.Order).Where(p => p.Order.Id == order.Id).ToListAsync();
                OrderGetModel orderGetModel = new OrderGetModel(order, products);
                return orderGetModel;
            }
            catch (Exception ex) { 
                _logger.LogError($"Error while get order. {ex}");
                throw;
            }
        }
    }
}
