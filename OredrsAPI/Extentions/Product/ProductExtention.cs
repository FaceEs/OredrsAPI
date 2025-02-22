using OredrsAPI.Data.Models.Product;
using OredrsAPI.Extentions.Exceptions;

namespace OredrsAPI.Extentions.Product
{
    public static class ProductExtention
    {
        public static void Validate(this ProductEntry product)
        {
            if (product.Price <= 0)
            {
                throw new ValidationException("Цена продукта не может быть меньше либо равной нулю");
            }
            if (string.IsNullOrEmpty(product.Title))
            {
                throw new ValidationException("Название продукта не может быть пустым");
            }
        }
    }
}
