using Application.Features.Invoices.Rules;
using Application.Services.Invoices;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using MediatR;
using System.Net;

namespace Application.Features.Invoices.Queries.GetAdditionByQrCode;

public class GetAdditionByQrCodeQuery : IRequest<CustomResponseDto<GetAdditionByQrCodeResponse>>
{
    public string QrCode { get; set; }
    public class GetAdditionByQrCodeQueryHandler : IRequestHandler<GetAdditionByQrCodeQuery, CustomResponseDto<GetAdditionByQrCodeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IInvoicesService _invoicesService;
        private readonly InvoiceBusinessRules _invoiceBusinessRules;

        public GetAdditionByQrCodeQueryHandler(IMapper mapper, IInvoicesService invoicesService, InvoiceBusinessRules invoiceBusinessRules)
        {
            _mapper = mapper;
            _invoicesService = invoicesService;
            _invoiceBusinessRules = invoiceBusinessRules;
        }

        public async Task<CustomResponseDto<GetAdditionByQrCodeResponse>> Handle(GetAdditionByQrCodeQuery request, CancellationToken cancellationToken)
        {
            string path = await _invoicesService.AdditionGenerate(request.QrCode);
            GetAdditionByQrCodeResponse response = new() { Path = path };

            return CustomResponseDto<GetAdditionByQrCodeResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}
