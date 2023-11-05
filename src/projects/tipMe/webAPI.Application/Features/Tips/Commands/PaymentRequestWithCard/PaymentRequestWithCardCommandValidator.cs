using FluentValidation;

namespace Application.Features.Tips.Commands.PaymentRequestWithCard;

public class PaymentRequestWithCardCommandValidator : AbstractValidator<PaymentRequestWithCardCommand>
{
    public PaymentRequestWithCardCommandValidator() { }
}