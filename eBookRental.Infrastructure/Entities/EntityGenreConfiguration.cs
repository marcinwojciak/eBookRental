using eBookRental.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eBookRental.Infrastructure.Entities
{
    public class EntityGenreConfiguration
    {
        public EntityGenreConfiguration(EntityTypeBuilder<Genre> entity)
        {
            entity.ToTable("Genre");

            entity.Property(x => x.Name)
                  .IsRequired();
        }
    }
}
