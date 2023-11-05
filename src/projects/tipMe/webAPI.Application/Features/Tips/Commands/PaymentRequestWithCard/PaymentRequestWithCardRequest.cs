using Core.Application.Dtos;

namespace Application.Features.Tips.Commands.PaymentRequestWithCard;

public class PaymentRequestWithCardRequest : IDto
{
    public string QrCode { get; set; }
    public string CardHolderName { get; set; }
    public string CardNumber { get; set; }
    public string ExpireMonth { get; set; }
    public string ExpireYear { get; set; }
    public string Cvc { get; set; }
    public decimal TipAmount { get; set; }
    public decimal TaxAmount { get; set; }

}
