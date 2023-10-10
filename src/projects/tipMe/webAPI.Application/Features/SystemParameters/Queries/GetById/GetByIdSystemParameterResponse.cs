using Core.Application.Responses;

namespace Application.Features.SystemParameters.Queries.GetById;

public class GetByIdSystemParameterResponse : IResponse
{
    public Guid Id { get; set; }
    public string ParameterKey { get; set; }
    public string ParameterValue { get; set; }
    public string? SampleValue { get; set; }
    public string? Description { get; set; }
}