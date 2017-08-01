using eBookRental.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eBookRental.Infrastructure.Entities
{
    public class EntityBookConfiguration
    {
        public EntityBookConfiguration(EntityTypeBuilder<Book> entity)
        {
            entity.ToTable("Book");

            entity.Property(x => x.Title)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(x => x.Writer)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(m => m.Description)
                  .IsRequired()
                  .HasMaxLength(2000);

            entity.Property(x => x.Image)
                  .IsRequired();

            entity.Property(x => x.Publisher)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(x => x.NumberOfSets)
                  .IsRequired();

            entity.Property(x => x.GenreId)
                  .IsRequired();

            entity.HasMany(m => m.Sets)
                  .WithOne()
                  .HasForeignKey(x => x.BookId);
        }
    }
}
