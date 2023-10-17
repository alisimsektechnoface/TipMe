using Core.Application.Responses;

namespace Application.Features.Stores.Commands.Update;

public class UpdatedStoreResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; }
}