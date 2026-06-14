using CleanArchitecture.Application.Exception;
using CleanArchitecture.Application.Utilies;
using FluentValidation;
using FluentValidation.Results;
namespace CleanArchitecture.Application.Mediator
{
    public class Mediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;
        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            //İstek türünü alıyoruz.
            // var requestType = request.GetType();
            //Send çağrıldıktan hemen sonra FluentValidation kullanarak isteği doğruluyoruz.
            //İstek türüne uygun bir validator buluyoruz ve doğrulama işlemini gerçekleştiriyoruz.
            //Eğer doğrulama başarısız olursa, bir CustomValidationException fırlatıyoruz.
            var validatorType = typeof(IValidator<>).MakeGenericType(request.GetType());
            //Gelen verinin doğru olup olmadığını kontrol etmek için FluentValidation kullanarak doğrulama yapıyoruz.
            var validator = _serviceProvider.GetService(validatorType) as IValidator;

            if (validator != null)
            {
                var validate = validatorType.GetMethod("ValidateAsync");
                var taskToValidate = (Task)validate!.Invoke(validator, new object[] { request, default(CancellationToken) })!;
                await taskToValidate;
                var result = taskToValidate.GetType().GetProperty("Result")!;
                var validationResult = (ValidationResult)result!.GetValue(taskToValidate)!;
                if (!validationResult.IsValid)
                {
                    //Global Exception Middleware tarafından yakalanır
                    //HTTP 400 olarak dönebilir veya farklı bir şekilde işlenebilir.
                    throw new CustomValidationException(validationResult);
                }
            }
            //İstek türüne uygun bir handler buluyoruz.
            //Request tipine uygun handler’ı runtime’da arar
            //IServiceProvider (DI container) üzerinden resolve eder
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            var handler = _serviceProvider.GetService(handlerType);
            //İstekle ilgili bir handler bulunamazsa hata fırlatıyoruz.
            if (handler == null)
            {
                throw new MediatorException($"No handler found for request type {request.GetType().Name}");
            }
            //Handler'ı çalıştırarak cevabı alıyoruz.
            var handleMethod = handlerType.GetMethod("Handle");
            if (handleMethod == null)
            {
                throw new MediatorException($"No Handle method found in handler type {handlerType.Name}");
            }
            //business logic
            var response = await (Task<TResponse>)handleMethod.Invoke(handler, new object[] { request });
            return response;
        }
    }
}
