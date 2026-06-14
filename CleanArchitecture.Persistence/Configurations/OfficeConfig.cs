using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CleanArchitecture.Persistence.Migrations
{
    internal class OfficeConfig : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Office");
            builder.HasKey(x => x.Id);
            builder.Property(o => o.Name).HasMaxLength(100).IsRequired();
        }
    }
}
