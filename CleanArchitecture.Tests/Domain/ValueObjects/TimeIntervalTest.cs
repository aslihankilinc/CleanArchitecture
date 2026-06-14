using CleanArchitecture.Domain.Exceptions;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Tests.Domain.ValueObjects
{
    [TestClass]
    public class TimeIntervalTest
    {
        [TestMethod]
        public void ConstructorStartBeforeEnd()
        {
            Assert.ThrowsExactly<BusinessRuleException>(() =>
            new TimeInterval(DateTime.Now, DateTime.Now.AddDays(-3)));
        }
    }
}
