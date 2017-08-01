using eBookRental.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eBookRental.Infrastructure.Entities
{
    public class EntityUserConfiguration
    {
        public EntityUserConfiguration(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("User");

            entity.Property(x => x.Username)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(u => u.FullName)
                  .IsRequired()
                  .HasMaxLength(200);

            entity.Property(x => x.Email)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(x => x.Password)
                  .IsRequired()
                  .HasMaxLength(200);

            entity.Property(x => x.Salt)
                  .IsRequired()
                  .HasMaxLength(200);

            entity.Property(x => x.Mobile)
                  .HasMaxLength(9);

            entity.Property(x => x.IdentityCard)
                  .HasMaxLength(16);
        }
    }
}
