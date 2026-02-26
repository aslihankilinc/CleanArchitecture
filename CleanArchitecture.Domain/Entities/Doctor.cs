using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class Doctor
    {
        public Guid Id { get; private set; }    
        public string Name { get; private set; }=null!;
        public string Email { get; private set; } = null!;
    }
}
