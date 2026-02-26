using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Domain.ValueObjects
{
    //Value Object: E-mail adresini temsil eden bir Value Object tanımlıyoruz.
    //değiştirilemez (immutable) bir yapıya sahip ve sadece geçerli bir e-mail adresi içerebilir.
    //Bundan ötürü  record kullanıyoruz
    public record Email
    {
        //e-mail adresinin geçerli bir formatta olup olmadığını kontrol ediyoruz.
        //Bu, domain katmanında tanımlanan bir iş kuralıdır ve ihlal edildiğinde BusinessRuleException fırlatır.
        public string Value { get;  } = null!;
        public Email(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new BusinessRuleException($"Doctor {nameof(email)} cannot be null or empty.");
            }
            if (!email.Contains("@"))
            {
                throw new BusinessRuleException($"Doctor {nameof(email)} must be a valid email address.");
            }
            Value = email;
        }
    }
}
