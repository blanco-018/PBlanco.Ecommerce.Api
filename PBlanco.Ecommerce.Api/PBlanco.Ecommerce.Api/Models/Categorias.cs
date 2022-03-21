using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PBlanco.Ecommerce.Api.Models
{
    public class Categorias
    {
        public int Id { get; set; }

        public string NombreProducto { get; set; }
        public string DescripcionProducto { get; set; }

        [JsonIgnore]
        public IEnumerable<Producto> Productos { get; set; }

    }
}
