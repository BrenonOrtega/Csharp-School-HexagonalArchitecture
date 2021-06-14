using System;

namespace SchoolApp.Domain.Entities.Shared
{
    public interface IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set;}
    }
}