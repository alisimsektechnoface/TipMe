using Core.Application.Responses;

namespace Application.Features.Waiters.Queries.GetById;

public class GetByIdWaiterResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StoreId { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; }
}