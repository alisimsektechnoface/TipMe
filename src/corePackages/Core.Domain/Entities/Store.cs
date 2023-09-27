using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Store : Entity<Guid>
    {
        public string Name { get; set; }

        public Store()
        {
        }

        public Store(Guid id, string name) : this()
        {
            Id = id;
            Name = name;
        }

    }
}
