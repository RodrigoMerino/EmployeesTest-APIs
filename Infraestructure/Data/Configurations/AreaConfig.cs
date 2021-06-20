using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Data.Configurations
{
    class AreaConfig : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.ToTable("areas");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.AreaName)
                .HasColumnName("area_name")
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
