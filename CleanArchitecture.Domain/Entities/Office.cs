using CleanArchitecture.Domain.Exceptions;

namespace CleanArchitecture.Domain.Entities
{
    public class Office
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;

        //Geçersiz state’i engelleme
        //Office nesnesi oluşturulurken name null veya empty olamaz.
        //Bu nedenle constructor’da bu kontrolü yapıyoruz.
        public Office(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                //Domain kendi kuralını tanımlar ve ihlal edildiğinde BusinessRuleException fırlatır.
                throw new BusinessRuleException($"Office {nameof(name)} cannot be null or empty.");
            }
            Name = name;
            //veritabanı tarafından oluşturulan identity yerine, domain tarafından oluşturulan identity kullanıyoruz.
            //Guid.NewGuid() yerine Guid.CreateVersion7() kullanarak daha performanslı ve sıralanabilir bir ID oluşturuyoruz.
            Id = Guid.CreateVersion7();
        }

    }
}
