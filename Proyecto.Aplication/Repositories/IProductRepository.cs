using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Domain.Entities.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto.Aplication.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetAllAsync();
        Task<ProductEntity> GetByIdAsync(int id);
        Task AddAsync(ProductEntity producto);
        Task UpdateAsync(ProductEntity producto);
        Task DeleteAsync(int id);
    }
}
