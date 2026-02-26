using CleanArchitecture.Domain.Exceptions;
using CleanArchitecture.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class Visitor
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public Email Email { get; private set; } = null!;
        public Visitor(string name, Email email)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new BusinessRuleException($"Doctor {nameof(name)} cannot be null or empty.");
            }
           if(email is null)
            {
                throw new BusinessRuleException($"Doctor {nameof(email)} cannot be null.");
            }
            Id = Guid.CreateVersion7();
            Name = name;
            Email = email;
        }
    }
}
