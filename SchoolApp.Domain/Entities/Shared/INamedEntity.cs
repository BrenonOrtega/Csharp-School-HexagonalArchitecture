using SchoolApp.Domain.ValueObjects;

namespace SchoolApp.Domain.Entities.Shared
{
    public interface INamedEntity : IEntity
    {
        public Name Name { get; set; }
    }
}