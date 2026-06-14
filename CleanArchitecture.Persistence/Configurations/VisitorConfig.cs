using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Persistence.Configurations
{
    internal class VisitorConfig : IEntityTypeConfiguration<Visitor>
    {
        public void Configure(EntityTypeBuilder<Visitor> builder)
        {
            builder.ToTable("Visitor");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email)
               .HasColumnName("Email")
               .HasMaxLength(50)
               .HasConversion(
                   emailNesnesi => emailNesnesi.Value,
                   stringDeger => new Email(stringDeger)
               );
            builder.Property(o => o.Name).HasMaxLength(100).IsRequired();
        }
    }
}
