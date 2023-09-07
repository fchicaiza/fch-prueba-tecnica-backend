using fch_prueba_tecnica_backend.Models;
using fch_prueba_tecnica_backend.Repositories;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(await db.GetAllProducts());

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetails(string id)
        {
            return Ok(await db.GetProductById(id));
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

            product.Id = new MongoDB.Bson.ObjectId(id); 
            await db.UpdateProduct(product);

            return Created("Product Updated successfully", true);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await db.DeleteProduct(id);
            return NoContent();
        }


    }
}
