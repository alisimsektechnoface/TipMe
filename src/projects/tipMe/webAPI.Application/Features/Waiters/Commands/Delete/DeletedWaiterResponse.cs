using Core.Application.Responses;

namespace Application.Features.Waiters.Commands.Delete;

public class DeletedWaiterResponse : IResponse
{
    public Guid Id { get; set; }
}