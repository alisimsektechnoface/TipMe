using Core.Application.Dtos;

namespace Application.Features.Tips.Commands.PaymentRequestMobile;

public class PaymentRequestMobileOptions : IDto
{
    public string ApiKey { get; set; }

    public string SecretKey { get; set; }

    public string BaseUrl { get; set; }
    public string ThirdPartyClientId { get; set; }
    public string ThirdPartyClientSecret { get; set; }
    public string SdkType { get; set; }
    public string BaseUrlMobile { get; set; }
}
