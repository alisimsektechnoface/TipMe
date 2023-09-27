using FluentValidation;

namespace Application.Features.Tips.Commands.Create;

public class CreateTipCommandValidator : AbstractValidator<CreateTipCommand>
{
    public CreateTipCommandValidator()
    {
        //RuleFor(c => c.RequestDate).NotEmpty();
        //RuleFor(c => c.QrCode).NotEmpty();
        //RuleFor(c => c.IsTipped).NotEmpty();
        //RuleFor(c => c.PaymentDate).NotEmpty();
        //RuleFor(c => c.PaymentReference).NotEmpty();
        //RuleFor(c => c.IsCommented).NotEmpty();
        //RuleFor(c => c.Comment).NotEmpty();
        //RuleFor(c => c.CommentDate).NotEmpty();
        //RuleFor(c => c.Point).NotEmpty();
    }
}