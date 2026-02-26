using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Exceptions;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Tests.Domain.Entities
{
    [TestClass]
    public class DoctorTest
    {
        [TestMethod]
        public void ConstructorNameNotEmpty()
        {
            var email = new Email("test@mail.com");
            Assert.ThrowsExactly<BusinessRuleException>(() =>
            new Doctor(null!, email));
        }
        [TestMethod]
        public void ConstructorEmailNotNull()
        {
            Assert.ThrowsExactly<BusinessRuleException>(() =>
            new Doctor("Test", null!));
        }
    }
}
