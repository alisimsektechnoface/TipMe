using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Contract : Entity<Guid>
    {
        public string Url { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Contract()
        {
        }

        public Contract(string url, string? name, string? description) : this()
        {
            Url = url;
            Name = name;
            Description = description;
        }
    }
}