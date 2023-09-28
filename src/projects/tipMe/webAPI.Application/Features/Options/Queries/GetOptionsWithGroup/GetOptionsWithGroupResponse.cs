using Application.Features.Options.Queries.GetById;
using Core.Application.Dtos;

namespace Application.Features.Options.Queries.GetOptionsWithGroup;

public class GetOptionsWithGroupResponse : IDto
{
    public List<GetByIdOptionResponse> Happy { get; set; }
    public List<GetByIdOptionResponse> Unhappy { get; set; }
}
