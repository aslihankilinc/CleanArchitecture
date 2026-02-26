using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get;  set; }
        public Guid DoctorId { get;  set; }
        public  Guid VisitorId { get;  set; }
        public Guid OfficeId { get;  set; }
        public AppointmentStatus Status { get;  set; }
        public DateTime StartTime { get;  set; }
        public DateTime EndTime { get;  set; }
        public Doctor? Doctor { get;  set; } 
        public Visitor? Visitor { get;  set; } 
        public Office? Office { get;  set; }  
    }
}
