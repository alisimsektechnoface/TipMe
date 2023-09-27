using Application.Features.Waiters.Commands.Create;
using Application.Features.Waiters.Commands.Delete;
using Application.Features.Waiters.Commands.Update;
using Application.Features.Waiters.Queries.GetById;
using Application.Features.Waiters.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WaitersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateWaiterCommand createWaiterCommand)
    {
        CustomResponseDto<CreatedWaiterResponse> response = await Mediator.Send(createWaiterCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateWaiterCommand updateWaiterCommand)
    {
        CustomResponseDto<UpdatedWaiterResponse> response = await Mediator.Send(updateWaiterCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        CustomResponseDto<DeletedWaiterResponse> response = await Mediator.Send(new DeleteWaiterCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        CustomResponseDto<GetByIdWaiterResponse> response = await Mediator.Send(new GetByIdWaiterQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListWaiterQuery getListWaiterQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListWaiterListItemDto>> response = await Mediator.Send(getListWaiterQuery);
        return Ok(response);
    }
}