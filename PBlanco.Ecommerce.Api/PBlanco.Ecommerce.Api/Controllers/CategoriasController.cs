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
    public class CategoriasController : ControllerBase
    {
        private readonly EcommerceDB _context;

        public CategoriasController(EcommerceDB context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categorias>> GetAllCategorias()
        {
            if (_context.Categoria.Any())
                return Ok(_context.Categoria);
            else
                return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult GetCategoriasById(int id)
        {
            if (_context.Categoria.Any(c => c.Id == id))
                return Ok(_context.Categoria.FirstOrDefault(c => c.Id == id));
            else
                return NoContent();
        }

        [HttpPost]
        public IActionResult AddCategorias([FromBody] Categorias categoria)
        {
            if (!_context.Categoria.Any(c => c.Id == categoria.Id))
            {
                _context.Categoria.Add(categoria);
                _context.SaveChanges();
                return Ok();

            }
            else
            {
                return BadRequest($"La categoria con id : {categoria.Id} , ya existe");
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategorias(int id, [FromBody] Categorias categoria)
        {
            if (_context.Categoria.Any(c => c.Id == id))
            {
                var CategoryToUpdate = _context.Categoria.Single(c => c.Id == id);
                _context.Categoria.Remove(CategoryToUpdate);
                _context.Categoria.Add(categoria);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest($"No existe ninguna categoria con el id : {id}");
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategorias(int id)
        {
            if (_context.Categoria.Any(c => c.Id == id))
            {
                var CategoryToDelete = _context.Categoria.Single(c => c.Id == id);
                _context.Categoria.Remove(CategoryToDelete);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest($"No existe ninguna categoria con el id : {id}");
            }

        }
    }
}

