using BussinessLogicLayer.IServices;
using DataAccessLayer.DataContextFolder;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BussinessLogicLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dataContext;
        public ProductService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _dataContext.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await _dataContext.Products.FindAsync(id);

            return product;
        }

        public async Task<bool> UpdateProductAsync(int id, Product product)
        {
            if (id != product.Id)
            {
                return false;
            }

            _dataContext.Entry(product).State = EntityState.Modified;

            try
            {
                await _dataContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!EmployeeExists(id))
                //{
                //    return badreq;
                //}
                //else
                //{
                //    throw;
                //}
                return false;
            }

            return true;
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            _dataContext.Products.Add(product);
            await _dataContext.SaveChangesAsync();

            return productExists(product.Id);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await GetProduct(id);

            _dataContext.Products.Remove(product);
            await _dataContext.SaveChangesAsync();

            return !productExists(id);
        }

        private bool productExists(int id)
        {
            return _dataContext.Products.Any(e => e.Id == id);
        }
    }
}
