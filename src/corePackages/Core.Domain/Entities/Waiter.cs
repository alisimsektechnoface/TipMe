using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Waiter : Entity<Guid>
    {
        public Guid StoreId { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }

        public Waiter()
        {
        }

        public Waiter(Guid id, Guid stroreId, string name, string photo) : this()
        {
            Id = id;
            StoreId = stroreId;
            Name = name;
            Photo = photo;
        }

    }
}
