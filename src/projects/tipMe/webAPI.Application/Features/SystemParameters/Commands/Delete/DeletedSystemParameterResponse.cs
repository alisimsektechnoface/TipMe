using Core.Application.Responses;

namespace Application.Features.SystemParameters.Commands.Delete;

public class DeletedSystemParameterResponse : IResponse
{
    public Guid Id { get; set; }
}