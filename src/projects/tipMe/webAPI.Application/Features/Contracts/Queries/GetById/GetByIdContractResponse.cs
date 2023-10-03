using Core.Application.Responses;

namespace Application.Features.Contracts.Queries.GetById;

public class GetByIdContractResponse : IResponse
{
    public Guid Id { get; set; }
    public string Url { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}