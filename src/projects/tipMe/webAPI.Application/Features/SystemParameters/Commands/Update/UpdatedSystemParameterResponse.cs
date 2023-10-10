using Core.Application.Responses;

namespace Application.Features.SystemParameters.Commands.Update;

public class UpdatedSystemParameterResponse : IResponse
{
    public Guid Id { get; set; }
    public string ParameterKey { get; set; }
    public string ParameterValue { get; set; }
    public string? SampleValue { get; set; }
    public string? Description { get; set; }
}