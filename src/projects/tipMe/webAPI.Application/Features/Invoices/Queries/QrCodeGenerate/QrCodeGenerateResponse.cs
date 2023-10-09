using Core.Application.Responses;

namespace Application.Features.Invoices.Queries.QrCodeGenerate;

public class QrCodeGenerateResponse : IResponse
{
    public string Path { get; set; }
}
