using Core.Application.Dtos;

namespace Application.Features.SystemParameters.Queries.GetList;

public class GetListSystemParameterListItemDto : IDto
{
    public Guid Id { get; set; }
    public string ParameterKey { get; set; }
    public string ParameterValue { get; set; }
    public string? SampleValue { get; set; }
    public string? Description { get; set; }
}