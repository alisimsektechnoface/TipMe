using Core.Application.Responses;

namespace Application.Features.Options.Queries.GetById;

public class GetByIdOptionResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    public bool IsHappy { get; set; }
}