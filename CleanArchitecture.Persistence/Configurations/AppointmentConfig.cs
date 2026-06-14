using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistence.Configurations
{
    internal class AppointmentConfig:IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointment");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Doctor).WithMany(x => x.Appointments).HasForeignKey(x => x.DoctorId);
            builder.HasOne(x => x.Office).WithMany(x => x.Appointments).HasForeignKey(x => x.OfficeId);
            builder.HasOne(x => x.Visitor).WithMany().HasForeignKey(x => x.VisitorId);
            //TimeInterval mapleme
            builder.OwnsOne(x => x.TimeInterval, time =>
            {
                time.Property(t => t.StartTime)
                    .HasColumnName("StartTime");

                time.Property(t => t.EndTime)
                    .HasColumnName("EndTime");
            });
        }
    }
}
