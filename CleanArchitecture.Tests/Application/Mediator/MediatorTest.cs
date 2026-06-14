
using CleanArchitecture.Application.Exception;
using CleanArchitecture.Application.Utilies;
using FluentValidation;
using NSubstitute;
namespace CleanArchitecture.Tests.Application.Mediator
{
    [TestClass]
    public class MediatorTest
    {
        //Request  →  Mediator  →  ServiceProvider  →  Handler

        //FluentValidation  → Request doğru mu kontrol eder
        //NSubstitute  →  Handler’ı fake yapar
        //Mediator  →  İkisini birleştirir
        public class FalseRequest : IRequest<string>
        {
            public required string Data { get; set; }
        }
        public class FalseRequestValidator : AbstractValidator<FalseRequest>
        {
            public FalseRequestValidator()
            {
                RuleFor(x => x.Data).NotEmpty();
            }
        }

        //Eğer bir handler register edilmişse, Send çağrıldığında Handle metodu çalıştırılmalı
        [TestMethod]
        public async Task Send_WithRegisteredHandler_HandleIsExecuted()
        {
            // Gerçek handler yerine sahte bir handler oluşturuluyor
            var request = new FalseRequest() { Data = "Asliko" };
            //Dependency Injection container’ın sahte versiyonu oluşturuluyor
            //Gerçek handler yazma, sahte bir tane ver
            var handlerMock = Substitute.For<IRequestHandler<FalseRequest, string>>();
            //Bu tip için gerçek handler değil, mock handler ver
            var serviceProvider = Substitute.For<IServiceProvider>();
            serviceProvider.GetService(typeof(IRequestHandler<FalseRequest, string>))
            .Returns(handlerMock);

            var mediator = new CleanArchitecture.Application.Mediator.Mediator(serviceProvider);
            var result = await mediator.Send(request);
            await handlerMock.Received(1).Handle(request);
        }

        [TestMethod]
        public async Task Send_WithoutRegisteredHandler_ThrowsMediatorException()
        {
            var request = new FalseRequest() { Data = "Asliko" };
            var serviceProvider = Substitute.For<IServiceProvider>();

            serviceProvider
                .GetService(typeof(IRequestHandler<FalseRequest, string>))
                .Returns(null);

            var mediator = new CleanArchitecture.Application.Mediator.Mediator(serviceProvider);

            await Assert.ThrowsAsync<MediatorException>(async () =>
            {
                await mediator.Send(request);
            });
        }

        [TestMethod]
        public async Task Send_InvalidCommand_Throws()
        {
            var request = new FalseRequest() { Data = "" };
            var serviceProvider = Substitute.For<IServiceProvider>();
            var validator = new FalseRequestValidator();
            serviceProvider.GetService(typeof(IValidator<FalseRequest>)).Returns(validator);
            var mediator = new CleanArchitecture.Application.Mediator.Mediator(serviceProvider);
            await Assert.ThrowsAsync<CustomValidationException>(async () =>
            {
               object value = await mediator.Send(request);
            });
        }



    }
}