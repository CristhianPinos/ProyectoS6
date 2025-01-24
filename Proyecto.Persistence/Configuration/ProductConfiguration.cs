using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Persistence.Configuration
{
    public class ProductConfiguration
    {
        public ProductConfiguration(EntityTypeBuilder<ProductEntity> entityBuilder) {
            entityBuilder.HasKey(x => x.ProductId);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Description).HasMaxLength(50);
            entityBuilder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
            entityBuilder.Property(x => x.Stock).IsRequired();
        }
    }
}
