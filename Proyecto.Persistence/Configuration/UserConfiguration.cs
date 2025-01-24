using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Domain.Entities.User;

namespace Proyecto.Persistence.Configuration
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<UserEntity> entityBuilder) {
        entityBuilder.HasKey(x=> x.UserId);
        entityBuilder.Property(x => x.FirstName).IsRequired();
        entityBuilder.Property(x => x.LastName).IsRequired();
        entityBuilder.Property(x => x.UserName).IsRequired();
        entityBuilder.Property(x => x.Password).IsRequired();

            entityBuilder.HasMany(x => x.Bookings)
                .WithOne(x => x.Users)
                .HasForeignKey(x=>x.UserId);
        }
    }
}
