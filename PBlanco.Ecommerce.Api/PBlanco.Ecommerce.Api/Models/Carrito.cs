using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PBlanco.Ecommerce.Api.Models
{
    public class Carrito
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int Cantidad { get; set; }
        public int ProductoId { get; set; }
        [JsonIgnore]
        public Producto Producto { get; set; }

        public string ProductName => Producto.NombreProducto;
        public decimal Precio => Producto.Precio;
        public decimal Total => Producto.Precio * Cantidad;
    }
}
