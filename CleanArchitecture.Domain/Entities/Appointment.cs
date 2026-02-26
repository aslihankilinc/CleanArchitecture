using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Domain.Exceptions;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public Guid VisitorId { get; set; }
        public Guid OfficeId { get; set; }
        public AppointmentStatus Status { get; set; }
        public TimeInterval TimeInterval { get; set; }
        public Doctor? Doctor { get; set; }
        public Visitor? Visitor { get; set; }
        public Office? Office { get; set; }
        public Appointment(Guid doctorId, Guid visitorId, Guid officeId, TimeInterval time)
        {
            if (time.StartTime < DateTime.UtcNow)
            {
                throw new BusinessRuleException("StartTime cannot be in the past.");
            }
            Id = Guid.CreateVersion7();
            DoctorId = doctorId;
            VisitorId = visitorId;
            OfficeId = officeId;
            TimeInterval = time;
            Status = AppointmentStatus.Scheduled; // Randevu oluşturulduğunda varsayılan olarak Scheduled durumunda başlar.
        }
        public void Cancel()
        {
            if (Status!= AppointmentStatus.Scheduled)
            {
                throw new BusinessRuleException("Only scheduled Appointment is already cancelled.");
            }
            Status = AppointmentStatus.Cancelled;
        }
        public void Complete()
        {
            if (Status != AppointmentStatus.Scheduled)
            {
                throw new BusinessRuleException("Only scheduled Appointment is already completed.");
            }
            Status = AppointmentStatus.Completed;
        }

    }
}
