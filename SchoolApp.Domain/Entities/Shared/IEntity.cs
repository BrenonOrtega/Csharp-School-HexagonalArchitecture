using System;

namespace SchoolApp.Domain.Entities.Shared
{
    public interface IEntity
    {
        public int Id { get; }
        public DateTime CreatedAt { get; }
        public DateTime ModifiedAt { get; }
    }
}