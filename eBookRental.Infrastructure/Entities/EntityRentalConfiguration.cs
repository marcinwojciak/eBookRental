using eBookRental.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eBookRental.Infrastructure.Entities
{
    public class EntityRentalConfiguration
    {
        public EntityRentalConfiguration(EntityTypeBuilder<Rental> entity)
        {
            entity.ToTable("Rental");

            entity.Property(r => r.UserId)
                  .IsRequired();

            entity.Property(r => r.SetId)
                  .IsRequired();

            entity.Property(r => r.Status)
                  .IsRequired()
                  .HasMaxLength(10);
        }
    }
}
