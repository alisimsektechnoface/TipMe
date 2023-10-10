using Core.Application.Responses;

namespace Application.Features.SystemParameters.Commands.Create;

public class CreatedSystemParameterResponse : IResponse
{
    public Guid Id { get; set; }
    public string ParameterKey { get; set; }
    public string ParameterValue { get; set; }
    public string? SampleValue { get; set; }
    public string? Description { get; set; }
}