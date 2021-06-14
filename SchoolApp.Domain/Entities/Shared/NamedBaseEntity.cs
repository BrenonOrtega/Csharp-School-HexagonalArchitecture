using SchoolApp.Domain.ValueObjects;

namespace SchoolApp.Domain.Entities.Shared
{
    public abstract class NamedBaseEntity : BaseEntity, INamedEntity
    {
        public Name Name { get; set; }
        public override string ToString() => $"ID:{ Id }-Name:{ Name }";
    }
}