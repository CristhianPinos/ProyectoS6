using Microsoft.AspNetCore.Mvc;
using Proyecto.Aplication.Repositories;
using Proyecto.Domain.Entities.Product;
using System.Threading.Tasks;
namespace Proyecto.Api.Controllers
{
    public class ProductControllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ProductosController : ControllerBase
        {
            private readonly IProductRepository _productoRepository;

            public ProductosController(IProductRepository productoRepository)
            {
                _productoRepository = productoRepository;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var productos = await _productoRepository.GetAllAsync();
                return Ok(productos);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var producto = await _productoRepository.GetByIdAsync(id);
                if (producto == null) return NotFound();
                return Ok(producto);
            }

            [HttpPost]
            public async Task<IActionResult> Create(ProductEntity producto)
            {
                await _productoRepository.AddAsync(producto);
                return CreatedAtAction(nameof(GetById), new { id = producto.ProductId }, producto);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, ProductEntity producto)
            {
                if (id != producto.ProductId) return BadRequest();
                await _productoRepository.UpdateAsync(producto);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                await _productoRepository.DeleteAsync(id);
                return NoContent();
            }
        }
    }
}
