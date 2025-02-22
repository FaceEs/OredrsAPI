using OredrsAPI.Data.Models.Product;

namespace OredrsAPI.Services.Product
{
    public class ProductService : IProductService
    {
        public Task<ProductEntry> AddProductAsync(ProductAddModel productAdd)
        {
            throw new NotImplementedException();
        }

        public Task<ProductEntry> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
