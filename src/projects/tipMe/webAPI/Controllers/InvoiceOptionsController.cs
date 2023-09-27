using Application.Features.InvoiceOptions.Commands.Create;
using Application.Features.InvoiceOptions.Commands.Delete;
using Application.Features.InvoiceOptions.Commands.Update;
using Application.Features.InvoiceOptions.Queries.GetById;
using Application.Features.InvoiceOptions.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Core.Application.ResponseTypes.Concrete;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoiceOptionsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateInvoiceOptionCommand createInvoiceOptionCommand)
    {
        CustomResponseDto<CreatedInvoiceOptionResponse> response = await Mediator.Send(createInvoiceOptionCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateInvoiceOptionCommand updateInvoiceOptionCommand)
    {
        CustomResponseDto<UpdatedInvoiceOptionResponse> response = await Mediator.Send(updateInvoiceOptionCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        CustomResponseDto<DeletedInvoiceOptionResponse> response = await Mediator.Send(new DeleteInvoiceOptionCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        CustomResponseDto<GetByIdInvoiceOptionResponse> response = await Mediator.Send(new GetByIdInvoiceOptionQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListInvoiceOptionQuery getListInvoiceOptionQuery = new() { PageRequest = pageRequest };
       CustomResponseDto<GetListResponse<GetListInvoiceOptionListItemDto>> response = await Mediator.Send(getListInvoiceOptionQuery);
        return Ok(response);
    }
}