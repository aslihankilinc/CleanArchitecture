using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Utilies
{
    public interface IMediator
    {
        //istek ve cevap tiplerini belirten bir generic metod tanımlıyoruz.
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
    }
}
