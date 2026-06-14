using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Contracts.Repositories;
using CleanArchitecture.Application.Utilies;
namespace CleanArchitecture.Application.Features.Office.Command.CreateOffice
{
    public class CreateOfficeCommandHandler:IRequestHandler<CreateOfficeCommand,Guid>
    {
        private readonly IOfficeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateOfficeCommandHandler(IOfficeRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateOfficeCommand command)
        {            
            var office = new Domain.Entities.Office(name: command.Name);
            try
            {
                var result = await _repository.AddAsync(office);
                await _unitOfWork.Commit();
                return result.Id;
            }
            catch (System.Exception)
            {
                await _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
