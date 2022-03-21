using Microsoft.EntityFrameworkCore;
using PBlanco.Ecommerce.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBlanco.Ecommerce.Api.Data
{
    public partial class EcommerceDB : DbContext
    {
        public DbSet<Carrito> Carrito{ get; set; }

        public DbSet<Categorias> Categoria { get; set; }

        public DbSet<Producto> Producto { get; set; }

        public EcommerceDB()
        { }

        public EcommerceDB(DbContextOptions<EcommerceDB> options) : base(options)
        {
        }
    }
}
