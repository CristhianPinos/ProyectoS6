using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto.Domain.Entities.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Persistence.Configuration
{
    public class CustomerConfiguration
    {
        public CustomerConfiguration(EntityTypeBuilder<CustomerEntity> entityBuilder) {
        entityBuilder.HasKey(x => x.CustomerId);
        entityBuilder.Property(x => x.FullName).IsRequired();
        entityBuilder.Property(x => x.DocumentNumber).IsRequired();

            entityBuilder.HasMany(x => x.Bookings)
                .WithOne(x => x.Customers)
                .HasForeignKey(x => x.CustomerId);
        }
    }
}
