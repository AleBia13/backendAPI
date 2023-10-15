using BussinessLogicLayer.IServices;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace backendAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //GET: /Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetEmployee()
        {
            var result = await _productService.GetProducts();

            if (result != null)
                return Ok(result);

            return BadRequest();
        }

        //GET: /Products/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducts(int id)
        {
            var result = await _productService.GetProduct(id);

            if (result != null)
                return Ok(result);

            return BadRequest();
        }


        //PUT: /Products/id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductAsync(int id, Product Product)
        {
            var successful = await _productService.UpdateProductAsync(id, Product);

            if (successful)
                return Ok(successful);

            return BadRequest();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> AddProductAsync(Product Product)
        {
            var successful = await _productService.AddProductAsync(Product);

            if (successful)
                return Ok(successful);

            return BadRequest();
        }

        // DELETE: Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var isDeleted = await _productService.DeleteProduct(id);

            if (isDeleted)
                return Ok();

            return BadRequest();
        }
    }
}
