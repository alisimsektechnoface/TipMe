using Application.Features.Stores.Commands.Create;
using Application.Features.Stores.Commands.Delete;
using Application.Features.Stores.Commands.Update;
using Application.Features.Stores.Queries.GetById;
using Application.Features.Stores.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StoresController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateStoreCommand createStoreCommand)
    {
        CustomResponseDto<CreatedStoreResponse> response = await Mediator.Send(createStoreCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateStoreCommand updateStoreCommand)
    {
        CustomResponseDto<UpdatedStoreResponse> response = await Mediator.Send(updateStoreCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        CustomResponseDto<DeletedStoreResponse> response = await Mediator.Send(new DeleteStoreCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        CustomResponseDto<GetByIdStoreResponse> response = await Mediator.Send(new GetByIdStoreQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListStoreQuery getListStoreQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListStoreListItemDto>> response = await Mediator.Send(getListStoreQuery);
        return Ok(response);
    }
}