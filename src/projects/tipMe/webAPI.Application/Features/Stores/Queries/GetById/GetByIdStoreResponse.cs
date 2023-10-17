using Core.Application.Responses;

namespace Application.Features.Stores.Queries.GetById;

public class GetByIdStoreResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; }
}