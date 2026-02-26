namespace CleanArchitecture.Domain.Entities
{
    public class Office
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }=null!;
    }
}
