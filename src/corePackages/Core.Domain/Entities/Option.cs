using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class Option : Entity<Guid>
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public bool IsHappy { get; set; }

        public Option()
        {
        }

        public Option(Guid id, string name, string icon, bool isHappy) : this()
        {
            Id = id;
            Name = name;
            Icon = icon;
            IsHappy = isHappy;
        }

    }
}
