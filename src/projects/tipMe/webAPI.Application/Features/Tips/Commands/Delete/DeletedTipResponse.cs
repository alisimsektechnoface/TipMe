using Core.Application.Responses;

namespace Application.Features.Tips.Commands.Delete;

public class DeletedTipResponse : IResponse
{
    public Guid Id { get; set; }
}