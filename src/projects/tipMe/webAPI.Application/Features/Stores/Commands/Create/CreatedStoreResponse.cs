using Core.Application.Responses;

namespace Application.Features.Stores.Commands.Create;

public class CreatedStoreResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}