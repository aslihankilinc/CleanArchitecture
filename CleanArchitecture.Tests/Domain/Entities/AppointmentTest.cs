using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Exceptions;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Tests.Domain.Entities
{
    [TestClass]
    public class AppointmentTest
    {
        private Guid doctorId = Guid.NewGuid();
        private Guid visitorId = Guid.NewGuid();
        private Guid officeId = Guid.NewGuid();
        private TimeInterval time = new TimeInterval(DateTime.UtcNow.AddHours(-2), DateTime.UtcNow.AddHours(-1));
        [TestMethod]
        public void ConstructorWhenStartTimeIsPastShouldThrowBusinessRuleException()
        {
            Assert.Throws<BusinessRuleException>(() =>
            new Appointment(doctorId, visitorId, officeId, time));

        }
        [TestMethod]
        public void CancelWhenStatusIsNotScheduledShouldThrowBusinessRuleException()
        {
            var appointment = new Appointment(doctorId, visitorId, officeId, new TimeInterval(DateTime.UtcNow.AddHours(1), DateTime.UtcNow.AddHours(2)));
            appointment.Cancel();
            Assert.Throws<BusinessRuleException>(() => appointment.Cancel());
        }
        [TestMethod]
        public void CompleteWhenStatusIsNotScheduledShouldThrowBusinessRuleException()
        {
            var appointment = new Appointment(doctorId, visitorId, officeId, new TimeInterval(DateTime.UtcNow.AddHours(1), DateTime.UtcNow.AddHours(2)));
            appointment.Complete();
            Assert.Throws<BusinessRuleException>(() => appointment.Complete());
        }
    }
}
