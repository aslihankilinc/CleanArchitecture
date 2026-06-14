using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Utilies
{
    public interface IRequestHandler<TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
    public interface IRequestHandler<TRequest>
    {
        Task Handle(TRequest request);
    }
}
