using Core.Application.Responses;

namespace Application.Features.Contracts.Commands.Delete;

public class DeletedContractResponse : IResponse
{
    public Guid Id { get; set; }
}