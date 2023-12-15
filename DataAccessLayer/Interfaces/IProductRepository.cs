using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<bool> UpdateProductAsync(int id, Product product);
        Task<bool> AddProductAsync(Product product);
        Task<bool> DeleteProduct(int id);

    }
}
