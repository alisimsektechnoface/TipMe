using Application.Features.Invoices.Rules;
using Application.Services.Invoices;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using MediatR;
using System.Net;

namespace Application.Features.Invoices.Queries.QrCodeGenerate;

public class QrCodeGenerateQuery : IRequest<CustomResponseDto<QrCodeGenerateResponse>>
{
    public string FileName { get; set; }
    public string Input { get; set; }
    public class QrCodeGenerateQueryHandler : IRequestHandler<QrCodeGenerateQuery, CustomResponseDto<QrCodeGenerateResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInvoicesService _invoicesService;
        private readonly InvoiceBusinessRules _invoiceBusinessRules;

        public QrCodeGenerateQueryHandler(IMapper mapper, IInvoicesService invoicesService, IInvoiceRepository invoiceRepository, InvoiceBusinessRules invoiceBusinessRules)
        {
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
            _invoicesService = invoicesService;
            _invoiceBusinessRules = invoiceBusinessRules;
        }

        public async Task<CustomResponseDto<QrCodeGenerateResponse>> Handle(QrCodeGenerateQuery request, CancellationToken cancellationToken)
        {
            string result = await _invoicesService.QrCodeGenerate(request.Input, request.FileName);
            QrCodeGenerateResponse response = _mapper.Map<QrCodeGenerateResponse>(result);

            return CustomResponseDto<QrCodeGenerateResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}
