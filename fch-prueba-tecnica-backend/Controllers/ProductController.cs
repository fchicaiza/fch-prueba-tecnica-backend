
using fch_prueba_tecnica_backend.Models;
using fch_prueba_tecnica_backend.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace fch_prueba_tecnica_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProductCollection db = new ProductCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await db.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetails(string id)
        {
            var product = await db.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null) return BadRequest();

            await db.InsertProduct(product);
            return Created("Product Created successfully", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product, string id)
        {
            if (product == null) return BadRequest();

            product.Id = id; // Asigna el valor de id al campo Id
            await db.UpdateProduct(product);

            return Created("Product Updated successfully", true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await db.DeleteProduct(id);
            return Created("Product Deleted successfully", true);
        }
    }
}
