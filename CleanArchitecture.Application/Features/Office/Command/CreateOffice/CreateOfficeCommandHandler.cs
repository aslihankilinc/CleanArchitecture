using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Contracts.Repositories;
using CleanArchitecture.Application.Exception;
using FluentValidation;
using System;
namespace CleanArchitecture.Application.Features.Office.Command.CreateOffice
{
    public class CreateOfficeCommandHandler
    {
        private readonly IOfficeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateOfficeCommand> _validator;
        public CreateOfficeCommandHandler(IOfficeRepository repository, IUnitOfWork unitOfWork,
            IValidator<CreateOfficeCommand> validator)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
            this._validator = validator;
        }
        public async Task<Guid> Handle(CreateOfficeCommand command)
        {
            var validationResult = await _validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult);
            }
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
