using Core.Application.Responses;
using Iyzipay.Request;

namespace Application.Features.Tips.Commands.PaymentRequestMobile;

public class PaymentRequestMobileResponse : IResponse
{
    public CreateCheckoutFormInitializeRequest PaymentBody { get; set; }
    public PaymentRequestMobileOptions Options { get; set; }
}
