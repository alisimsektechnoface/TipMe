using Core.Application.Responses;

namespace Application.Features.Stores.Commands.Delete;

public class DeletedStoreResponse : IResponse
{
    public Guid Id { get; set; }
}