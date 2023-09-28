using FluentValidation;

namespace Application.Features.Invoices.Queries.GetByQrCode;

public class GetByQrCodeQueryValidator : AbstractValidator<GetByQrCodeQuery>
{
    public GetByQrCodeQueryValidator() { }
}