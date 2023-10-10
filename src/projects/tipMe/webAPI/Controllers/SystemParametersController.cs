using Application.Features.SystemParameters.Commands.Create;
using Application.Features.SystemParameters.Commands.Delete;
using Application.Features.SystemParameters.Commands.Update;
using Application.Features.SystemParameters.Queries.GetById;
using Application.Features.SystemParameters.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SystemParametersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSystemParameterCommand createSystemParameterCommand)
    {
        CustomResponseDto<CreatedSystemParameterResponse> response = await Mediator.Send(createSystemParameterCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSystemParameterCommand updateSystemParameterCommand)
    {
        CustomResponseDto<UpdatedSystemParameterResponse> response = await Mediator.Send(updateSystemParameterCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        CustomResponseDto<DeletedSystemParameterResponse> response = await Mediator.Send(new DeleteSystemParameterCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        CustomResponseDto<GetByIdSystemParameterResponse> response = await Mediator.Send(new GetByIdSystemParameterQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSystemParameterQuery getListSystemParameterQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListSystemParameterListItemDto>> response = await Mediator.Send(getListSystemParameterQuery);
        return Ok(response);
    }
}