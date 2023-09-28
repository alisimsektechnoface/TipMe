using Application.Features.Invoices.Commands.Create;
using Application.Features.Invoices.Commands.Update;
using Application.Features.Invoices.Queries.GetById;
using Application.Features.Invoices.Queries.GetByQrCode;
using Application.Features.Invoices.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Microsoft.AspNetCore.Mvc;
using webAPI.Controllers.Base;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoicesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateInvoiceCommand createInvoiceCommand)
    {
        CustomResponseDto<CreatedInvoiceResponse> response = await Mediator.Send(createInvoiceCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateInvoiceCommand updateInvoiceCommand)
    {
        CustomResponseDto<UpdatedInvoiceResponse> response = await Mediator.Send(updateInvoiceCommand);

        return Ok(response);
    }

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> Delete([FromRoute] Guid id)
    //{
    //    CustomResponseDto<DeletedInvoiceResponse> response = await Mediator.Send(new DeleteInvoiceCommand { Id = id });

    //    return Ok(response);
    //}

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        CustomResponseDto<GetByIdInvoiceResponse> response = await Mediator.Send(new GetByIdInvoiceQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListInvoiceQuery getListInvoiceQuery = new() { PageRequest = pageRequest };
        CustomResponseDto<GetListResponse<GetListInvoiceListItemDto>> response = await Mediator.Send(getListInvoiceQuery);
        return Ok(response);
    }


    [HttpGet("GetByQrCode/{QrCode}")]
    public async Task<IActionResult> GetByQrCode([FromRoute] string QrCode)
    {
        GetByQrCodeQuery getByQrCodeQuery = new GetByQrCodeQuery() { QrCode = QrCode };
        CustomResponseDto<GetByQrCodeResponse> response = await Mediator.Send(getByQrCodeQuery);
        return Ok(response);
    }
}
