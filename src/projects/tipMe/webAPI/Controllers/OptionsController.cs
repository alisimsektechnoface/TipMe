using Application.Features.Options.Commands.Create;
using Application.Features.Options.Commands.Delete;
using Application.Features.Options.Commands.Update;
using Application.Features.Options.Queries.GetById;
using Application.Features.Options.Queries.GetList;
using Application.Features.Options.Queries.GetOptionsWithGroup;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Microsoft.AspNetCore.Mvc;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OptionsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateOptionCommand createOptionCommand)
    {
        CustomResponseDto<CreatedOptionResponse> response = await Mediator.Send(createOptionCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOptionCommand updateOptionCommand)
    {
        CustomResponseDto<UpdatedOptionResponse> response = await Mediator.Send(updateOptionCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        CustomResponseDto<DeletedOptionResponse> response = await Mediator.Send(new DeleteOptionCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        CustomResponseDto<GetByIdOptionResponse> response = await Mediator.Send(new GetByIdOptionQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListOptionQuery getListOptionQuery = new() { PageRequest = pageRequest };
        CustomResponseDto<GetListResponse<GetListOptionListItemDto>> response = await Mediator.Send(getListOptionQuery);
        return Ok(response);
    }

    [HttpGet("GetOptionsWithGroup")]
    public async Task<IActionResult> GetOptionsWithGroup()
    {
        GetOptionsWithGroupQuery getOptionsWithGroupQuery = new();
        CustomResponseDto<GetOptionsWithGroupResponse> response = await Mediator.Send(getOptionsWithGroupQuery);
        return Ok(response);
    }
}
