using DataAccessLayer.Models;

namespace BussinessLogicLayer.IServices
{
    public interface IProductService
    {
        Task<Product> GetProduct(int id);
        Task<IEnumerable<Product>> GetProducts();
        Task<bool> UpdateProductAsync(int id, Product product);
        Task<bool> AddProductAsync(Product product);
        Task<bool> DeleteProduct(int id);
    }
}
