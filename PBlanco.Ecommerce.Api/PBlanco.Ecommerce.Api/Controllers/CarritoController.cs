using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class CarritoController : ControllerBase
    {
        private readonly EcommerceDB _context;

        public CarritoController(EcommerceDB context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Carrito>> GetAllCarritos()
        {
            if (_context.Carrito.Any())
                return Ok(_context.Carrito.Include(c => c.Producto));
            else
                return NoContent();
        }

        [HttpGet("{email}")]
        public ActionResult<IEnumerable<Carrito>> GetCarritoByEmail(String email)
        {
            if (_context.Carrito.Any(c => c.Email.ToLower().Trim() == email.ToLower().Trim()))
                return Ok(_context.Carrito.Include(c => c.Producto).Where(c => c.Email.ToLower().Trim() == email.ToLower().Trim()));
            else
                return NoContent();
        }

        [HttpPost]
        public IActionResult AddCarrito([FromBody] Carrito carrito)
        {
            if (!_context.Carrito.Any(c => c.Id == carrito.Id))
            {
                _context.Carrito.Add(carrito);
                _context.SaveChanges();
                return Ok();

            }
            else
            {
                return BadRequest($"El carrito con id : {carrito.Id} ,ya existe :)");
            }

        }

        [HttpPut("{email}/{productoID}")]
        public IActionResult UpdateCarritos(String email, int productoID, [FromBody] int cantidad)
        {
            if (_context.Carrito.Any(c => c.Email.ToLower().Trim() == email.ToLower().Trim() && c.Id == productoID))
            {
                var CartToUpdate = _context.Carrito.Single(c => c.Email.ToLower().Trim() == email.ToLower().Trim() && c.Id == productoID);
                CartToUpdate.Cantidad = cantidad;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest($"No existe ningun carrito con el producto id :  {productoID} , ni con el correo ; {email}");
            }

        }

        [HttpDelete("{email}/{productoID}")]
        public IActionResult DeleteCarritoByIdOrEmail(String email, int productoID)
        {
            if (_context.Carrito.Any(c => c.Email.ToLower().Trim() == email.ToLower().Trim() && c.Id == productoID))
            {
                var CartToDelete = _context.Carrito.Single(c => c.Email.ToLower().Trim() == email.ToLower().Trim() && c.Id == productoID);
                _context.Carrito.Remove(CartToDelete);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest($"No existe ningun carrito con el producto id :  {productoID} , ni con el correo ; {email}");
            }

        }

        [HttpDelete("{email}")]
        public IActionResult DeleteCarritos(String email)
        {
            if (_context.Carrito.Any(c => c.Email.ToLower().Trim() == email.ToLower().Trim()))
            {
                var CartsToDelete = _context.Carrito.Where(c => c.Email.ToLower().Trim() == email.ToLower().Trim());
                _context.Carrito.RemoveRange(CartsToDelete);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest($"No existe carrito con el correo : {email}");
            }

        }

    }
}
