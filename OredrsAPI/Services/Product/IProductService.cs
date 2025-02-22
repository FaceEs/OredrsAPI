using OredrsAPI.Data.Models.Product;

namespace OredrsAPI.Services.Product
{
    public interface IProductService
    {
        public Task<ProductEntry> GetProductByIdAsync(int id);
        public Task<ProductEntry> AddProductAsync(ProductAddModel productAdd);
    }
}
