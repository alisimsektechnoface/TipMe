using Application.Features.Tips.Commands.Update;
using Application.Features.Tips.Queries.GetById;
using Application.Features.Tips.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Microsoft.AspNetCore.Mvc;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipsController : BaseController
{
    //[HttpPost]
    //public async Task<IActionResult> Add([FromBody] CreateTipCommand createTipCommand)
    //{
    //    CustomResponseDto<CreatedTipResponse> response = await Mediator.Send(createTipCommand);

    //    return Created(uri: "", response);
    //}

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTipCommand updateTipCommand)
    {
        CustomResponseDto<UpdatedTipResponse> response = await Mediator.Send(updateTipCommand);

        return Ok(response);
    }

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> Delete([FromRoute] Guid id)
    //{
    //    CustomResponseDto<DeletedTipResponse> response = await Mediator.Send(new DeleteTipCommand { Id = id });

    //    return Ok(response);
    //}

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        CustomResponseDto<GetByIdTipResponse> response = await Mediator.Send(new GetByIdTipQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTipQuery getListTipQuery = new() { PageRequest = pageRequest };
        CustomResponseDto<GetListResponse<GetListTipListItemDto>> response = await Mediator.Send(getListTipQuery);
        return Ok(response);
    }
}