using CleanArchitecture.Application.Contracts.Repositories;
using CleanArchitecture.Application.Exception;
using CleanArchitecture.Application.Features.Office.Queries.GetOfficeDetail;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
namespace CleanArchitecture.Tests.Application.Features.Office
{
    [TestClass]
    public class GetOfficeDetailQueryHandlerTest
    {

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IOfficeRepository _repository;
        private GetOfficeDetailQueryHandler handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            _repository = Substitute.For<IOfficeRepository>();
            handler = new GetOfficeDetailQueryHandler(_repository);
        }

        //Handler doğru mapping yapıyor mu
        [TestMethod]
        public async Task Handle_OfficeExists_ReturnsOfficeDetail()
        {
            var office = new CleanArchitecture.Domain.Entities.Office("Test Office");
            var id = office.Id;
            var query = new GetOfficeDetailQuery() { Id = id };
            _repository.GetByIdAsync(id).Returns(office);
            var result = await handler.Handle(query);
            Assert.IsNotNull(result);
            Assert.AreEqual(office.Id, result.Id);
            Assert.AreEqual(office.Name, result.Name);
        }
        //Office yoksa exception fırlatılıyor mu
        [TestMethod]
        public async Task Handle_OfficeDoesNotExists_Throws()
        {
            var id = Guid.NewGuid();
            var query = new GetOfficeDetailQuery { Id = id };
            _repository.GetByIdAsync(id).ReturnsNull();
            //async method'u await eder
            //exception'ı doğru şekilde yakalar
            //test framework'e bildirir
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(query);
            });
        }
    }
    
}
