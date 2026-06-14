using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Tests.Domain.Entities
{
    [TestClass]
    public class OfficeTest
    {
        [TestMethod]
        public void ConstructorNameNotEmpty()
        {
            Assert.ThrowsExactly<BusinessRuleException>(() =>
            new Office(null!));
        }
    }
}
