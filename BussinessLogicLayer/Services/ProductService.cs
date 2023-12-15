using BussinessLogicLayer.IServices;
using DataAccessLayer.DataContextFolder;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BussinessLogicLayer.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            var res = await _productRepository.AddProductAsync(product);

            return res;
        }

        public Task<bool> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProductAsync(int id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
