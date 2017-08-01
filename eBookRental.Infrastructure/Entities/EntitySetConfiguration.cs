using eBookRental.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eBookRental.Infrastructure.Entities
{
    public class EntitySetConfiguration
    {
        public EntitySetConfiguration(EntityTypeBuilder<Set> entity)
        {
            entity.ToTable("Set");

            entity.Property(x => x.IsAvailable)
                  .IsRequired();

            entity.HasMany(x => x.Rentals)
                  .WithOne(x => x.Set)
                  .HasForeignKey(x => x.SetId);
        }
    }
}
