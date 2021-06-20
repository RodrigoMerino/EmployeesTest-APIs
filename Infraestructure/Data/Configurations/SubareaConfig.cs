using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Data.Configurations
{
    class SubareaConfig : IEntityTypeConfiguration<Subarea>
    {
        public void Configure(EntityTypeBuilder<Subarea> builder)
        {
            builder.ToTable("subareas");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.IdArea).HasColumnName("id_area");

            builder.Property(e => e.SubareaName)
                .HasColumnName("subarea_name")
                .HasMaxLength(10)
                .IsFixedLength();

            builder.HasOne(d => d.IdAreaNavigation)
                .WithMany(p => p.Subareas)
                .HasForeignKey(d => d.IdArea)
                .HasConstraintName("FK_subareas_areas");
        }
    }
}

