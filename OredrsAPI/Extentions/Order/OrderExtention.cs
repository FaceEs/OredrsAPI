using OredrsAPI.Data.Models.Order;
using OredrsAPI.Extentions.Exceptions;

namespace OredrsAPI.Extentions.Order
{
    public static class OrderExtention
    {
        public static void Validate(this OrderEntry order)
        {
            if (string.IsNullOrEmpty(order.Customer))
            {
                throw new ValidationException("Поле \"Заказчик\" не может быть пустым");
            }
            if (string.IsNullOrEmpty(order.Number))
            {
                throw new ValidationException("Номер заказа не может быть пустым");
            }
        }
    }
}
