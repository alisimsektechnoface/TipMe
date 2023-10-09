using FluentValidation;

namespace Application.Features.Invoices.Queries.QrCodeGenerate;

public class QrCodeGenerateQueryValidator : AbstractValidator<QrCodeGenerateQuery>
{
    public QrCodeGenerateQueryValidator() { }
}