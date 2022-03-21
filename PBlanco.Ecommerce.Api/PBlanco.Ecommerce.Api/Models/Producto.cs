using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PBlanco.Ecommerce.Api.Models
{
    public class Producto
    {
        public int Id { get; set; }

        public string NombreProducto { get; set; }
        public string DescripcionProducto { get; set; }

        public decimal Precio { get; set; }

        public int CategoriaId { get; set; }

        [JsonIgnore]
        public Categorias Categoria { get; set; }
    }
}
