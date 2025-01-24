using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto.Domain.Entities.Product;
using Proyecto.Persistence.Configuration;

namespace Proyecto.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet para la entidad Product
        public DbSet<ProductEntity> Productos { get; set; }
    }
}
