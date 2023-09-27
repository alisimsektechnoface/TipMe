using Core.Application.Dtos;

namespace Application.Features.Waiters.Queries.GetList;

public class GetListWaiterListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid StoreId { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; }
}