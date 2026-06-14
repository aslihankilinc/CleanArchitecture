using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Contracts.Repositories;
using CleanArchitecture.Application.Features.Office.Command.CreateOffice;
using NSubstitute;
using CleanArchitecture.Domain.Entities;
namespace CleanArchitecture.Tests.Application.Features.Office
{
    [TestClass]
    public class CreateOfficeCommandHandlerTest
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IOfficeRepository _repository;
        private IUnitOfWork _unitOfWork;
        private CreateOfficeCommandHandler handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            //Mock repository and unit of work
            _repository = Substitute.For<IOfficeRepository>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            handler = new CreateOfficeCommandHandler(_repository, _unitOfWork);
        }

        [TestMethod]
        public async Task Handle_ValidCommand_ReturnsOfficeId()
        {
            var command = new CreateOfficeCommand() { Name = "Test Office" };
            var office = new CleanArchitecture.Domain.Entities.Office("Test Office");
            //AddAsync çagrılırsa, gerçek DB’ye gitme, direkt office döndür
            _repository.AddAsync(Arg.Any<CleanArchitecture.Domain.Entities.Office>()).Returns(office);
            var result = await handler.Handle(command);
            //AddAsync metodu tam 1 kere çagrılmıs mı
            await _repository.Received(1).AddAsync(Arg.Any<CleanArchitecture.Domain.Entities.Office>());
            await _unitOfWork.Received(1).Commit();
            //handlerdan dönen result, office.Id’ye eşit mi
            Assert.AreEqual(office.Id, result);

        }
    }
}
