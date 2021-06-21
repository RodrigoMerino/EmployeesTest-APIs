using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Data.Configurations
{
    class CustomEmployeeConfig : IEntityTypeConfiguration<CustomEmployee>
    {

        public void Configure(EntityTypeBuilder<CustomEmployee> builder)
        {

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Document)
                 .HasColumnName("doc")
                 .HasMaxLength(100)
                 .IsUnicode(false);

            builder.Property(e => e.IdArea).HasColumnName("id_area");

            builder.Property(e => e.IdSubarea).HasColumnName("id_subarea");

            builder.Property(e => e.LastName)
                 .HasColumnName("lastName")
                 .HasMaxLength(100)
                 .IsUnicode(false);

            builder.Property(e => e.Name)
                 .HasColumnName("name")
                 .HasMaxLength(100)
                 .IsUnicode(false);



            builder.Property(e => e.TypeDocument)
                 .HasColumnName("type_document")
                 .HasMaxLength(100)
                 .IsUnicode(false);


        }
    }
}
