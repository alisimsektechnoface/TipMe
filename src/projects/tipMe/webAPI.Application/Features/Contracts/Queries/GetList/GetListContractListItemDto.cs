using Core.Application.Dtos;

namespace Application.Features.Contracts.Queries.GetList;

public class GetListContractListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Url { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}