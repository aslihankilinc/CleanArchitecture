using CleanArchitecture.Domain.Exceptions;
using CleanArchitecture.Domain.ValueObjects;
namespace CleanArchitecture.Tests.Domain.ValueObjects
{
    [TestClass]
    public class EmailTest
    {
        [TestMethod]
        public void ConstructorNullEmail()
        {
            Assert.ThrowsExactly<BusinessRuleException>(() => new Email(null!));
        }

        [TestMethod]
        public void ConstructorCharEmail()
        {
            Assert.ThrowsExactly<BusinessRuleException>(() => new Email("asliko"));
        }
    }
}
