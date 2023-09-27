using Core.Application.Dtos;

namespace Application.Features.Options.Queries.GetList;

public class GetListOptionListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    public bool IsHappy { get; set; }
}