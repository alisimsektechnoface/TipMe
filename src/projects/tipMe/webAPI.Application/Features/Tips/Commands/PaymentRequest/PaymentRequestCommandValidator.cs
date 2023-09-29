using FluentValidation;

namespace Application.Features.Tips.Commands.PaymentRequest;

public class PaymentRequestCommandValidator : AbstractValidator<PaymentRequestCommand>
{
    public PaymentRequestCommandValidator() { }
}