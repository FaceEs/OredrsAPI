using Microsoft.AspNetCore.Mvc;
using OredrsAPI.Data.Models.Order;
using OredrsAPI.Extentions.Exceptions;
using OredrsAPI.Services.Order;

namespace OredrsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;
        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }
        /// <summary>
        /// Получение заказа по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id) {
            try
            {
                var order = await _orderService.GetOrderByIdAsync(id);
                return Ok(order);
            }
            catch (DbException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Создание заказа
        /// </summary>
        /// <param name="addModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderAddModel addModel)
        {
            try
            {
                var order = await _orderService.AddOrderAsync(addModel);
                return Ok(order.Id);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
