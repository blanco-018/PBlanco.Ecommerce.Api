using Microsoft.AspNetCore.Mvc;
using PBlanco.Ecommerce.Api.Data;
using PBlanco.Ecommerce.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBlanco.Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly EcommerceDB _context;

        public ProductosController(EcommerceDB context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Producto>> GetAllProductos()
        {
            if (_context.Producto.Any())
                return Ok(_context.Producto);
            else
                return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult GetProductosById(int id)
        {
            if (_context.Producto.Any(p => p.Id == id))
                return Ok(_context.Producto.FirstOrDefault(p => p.Id == id));
            else
                return NoContent();
        }

        [HttpGet("category/{id}")]
        public ActionResult<IEnumerable<Producto>> GetAllProductosByCategoriaId(int id)
        {
            if (_context.Producto.Any(c => c.CategoriaId == id))
                return Ok(_context.Producto.Where(c => c.CategoriaId == id));
            else
                return NoContent();
        }

        [HttpPost]
        public IActionResult AddProductos([FromBody] Producto producto)
        {
            if (!_context.Producto.Any(p => p.Id == producto.Id))
            {
                _context.Producto.Add(producto);
                _context.SaveChanges();
                return Ok();

            }
            else
            {
                return BadRequest($"Ya existe un producto con el id: {producto.Id}");
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateProductos(int id, [FromBody] Producto producto)
        {
            if (_context.Producto.Any(p => p.Id == id))
            {
                var ProductToUpdate = _context.Producto.Single(p => p.Id == id);
                _context.Producto.Remove(ProductToUpdate);
                _context.Producto.Add(producto);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest($"No existe ningun producto con el id : {id}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductos(int id)
        {
            if (_context.Producto.Any(p => p.Id == id))
            {
                var ProductToDelete = _context.Producto.Single(p => p.Id == id);
                _context.Producto.Remove(ProductToDelete);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest($"No existe ningun producto con el id : {id}");
            }

        }
    }
}
