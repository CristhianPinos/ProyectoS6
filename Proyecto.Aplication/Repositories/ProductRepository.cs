using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto.Domain.Entities.Product;
using Proyecto.Aplication.Repositories;
using Proyecto.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto.Aplication.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<ProductEntity> GetByIdAsync(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task AddAsync(ProductEntity producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductEntity producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
