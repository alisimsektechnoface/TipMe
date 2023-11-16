using Application.Features.Tips.Commands.PaymentRequest;
using Application.Features.Tips.Commands.PaymentRequestMobile;
using Application.Features.Tips.Commands.PaymentResult;
using Application.Features.Tips.Commands.PaymentResultQrCode;
using Application.Features.Tips.Commands.SavePaymentTokenMobile;
using Application.Features.Tips.Commands.Update;
using Application.Features.Tips.Queries.GetById;
using Application.Features.Tips.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Iyzipay.Model;
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

    //[HttpPost("PaymentRequestWithCart")]
    //public async Task<IActionResult> PaymentRequestWithCart([FromBody] PaymentRequestWithCardRequest paymentRequest)
    //{
    //    PaymentRequestWithCardCommand paymentRequestCommand = new() { Request = paymentRequest };
    //    var response = await Mediator.Send(paymentRequestCommand);
    //    return Ok(response);
    //}

    [HttpPost("PaymentRequest")]
    public async Task<IActionResult> PaymentRequest([FromBody] PaymentRequestCommand paymentRequestCommand)
    {
        CustomResponseDto<CheckoutFormInitialize> response = await Mediator.Send(paymentRequestCommand);
        return Ok(response);
    }



    [HttpPost("PaymentResult")]
    public async Task<IActionResult> PaymentResultToken(PaymentResultCommand paymentResultCommand)
    {
        //PaymentResultCommand paymentResultCommand = new PaymentResultCommand() { Token = paymentToken };
        CustomResponseDto<CheckoutForm> response = await Mediator.Send(paymentResultCommand);
        return Ok(response);
    }
    [HttpGet("PaymentResult/{qrCode}")]
    public async Task<IActionResult> PaymentResultQrCode([FromRoute] string qrCode)
    {
        PaymentResultQrCodeCommand paymentResultCommand = new PaymentResultQrCodeCommand() { QrCode = qrCode };
        CustomResponseDto<CheckoutForm> response = await Mediator.Send(paymentResultCommand);
        return Ok(response);
    }

    [HttpPost("PaymentRequestMobile")]
    public async Task<IActionResult> PaymentRequestMobile([FromBody] PaymentRequestMobileCommand paymentRequestCommand)
    {
        CustomResponseDto<PaymentRequestMobileResponse> response = await Mediator.Send(paymentRequestCommand);
        return Ok(response);
    }

    [HttpPost("SavePaymentTokenMobile")]
    public async Task<IActionResult> SavePaymentTokenMobile([FromBody] SavePaymentTokenMobileCommand paymentRequestCommand)
    {
        CustomResponseDto<bool> response = await Mediator.Send(paymentRequestCommand);
        return Ok(response);
    }



    //[HttpPost("TestUrl")]
    //[AllowAnonymous]
    //public async Task<IActionResult> TestUrl()
    //{
    //    return Redirect("http://localhost:4200/result/8D50C0E1-9C67-40EF-B26D-7564E1675B96-0126B432-CB95-4835-A5FA-5C63321FAA05");
    //}
}
