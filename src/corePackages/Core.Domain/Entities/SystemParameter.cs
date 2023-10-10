using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class SystemParameter : Entity<Guid>
    {
        public string ParameterKey { get; set; }
        public string ParameterValue { get; set; }
        public string? SampleValue { get; set; }
        public string? Description { get; set; }

        public SystemParameter()
        {

        }

        public SystemParameter(Guid id, string parameterKey, string parameterValue, string? sampleValue, string? description) : this()
        {
            Id = id;
            ParameterKey = parameterKey;
            ParameterValue = parameterValue;
            SampleValue = sampleValue;
            Description = description;
        }
    }
}
