using Core.Application.Dtos;

namespace Application.Features.Stores.Queries.GetList;

public class GetListStoreListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}