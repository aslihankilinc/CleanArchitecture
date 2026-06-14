using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Exception
{
    public class MediatorException: System.Exception
    {
        public MediatorException(string message):base(message)
        {
            
        }
    }
}
