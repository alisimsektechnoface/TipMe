using Application.Features.Options.Commands.Create;
using Application.Features.Options.Commands.Delete;
using Application.Features.Options.Commands.Update;
using Application.Features.Options.Queries.GetById;
using Application.Features.Options.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
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
}