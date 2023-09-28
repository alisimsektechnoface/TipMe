using Application.Features.Invoices.Rules;
using Application.Services.Invoices;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using MediatR;
using System.Net;
using static Application.Features.Invoices.Constants.InvoicesOperationClaims;

namespace Application.Features.Invoices.Queries.GetByQrCode;

public class GetByQrCodeQuery : IRequest<CustomResponseDto<GetByQrCodeResponse>>
{
    public string QrCode { get; set; }

    public string[] Roles => new[] { Admin, Read };
    public class GetByQrCodeQueryHandler : IRequestHandler<GetByQrCodeQuery, CustomResponseDto<GetByQrCodeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInvoicesService _invoiceService;
        private readonly InvoiceBusinessRules _invoiceBusinessRules;

        public GetByQrCodeQueryHandler(IMapper mapper, IInvoiceRepository invoiceRepository, IInvoicesService invoiceService, InvoiceBusinessRules invoiceBusinessRules)
        {
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
            _invoiceService = invoiceService;
            _invoiceBusinessRules = invoiceBusinessRules;
        }

        public async Task<CustomResponseDto<GetByQrCodeResponse>> Handle(GetByQrCodeQuery request, CancellationToken cancellationToken)
        {
            GetByQrCodeResponse response = await _invoiceService.GetByQrCode(request.QrCode, cancellationToken);

            //GetByQrCodeResponse response = _mapper.Map<GetByQrCodeResponse>(invoice);

            return CustomResponseDto<GetByQrCodeResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}
