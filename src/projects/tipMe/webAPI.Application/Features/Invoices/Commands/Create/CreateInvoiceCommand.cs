using Application.Features.Invoices.Constants;
using Application.Features.Invoices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Helpers.Helpers;
using MediatR;
using System.Net;
using System.Text.Json.Serialization;
using static Application.Features.Invoices.Constants.InvoicesOperationClaims;

namespace Application.Features.Invoices.Commands.Create;

public class CreateInvoiceCommand : IRequest<CustomResponseDto<CreatedInvoiceResponse>>
{
    public DateTime InvoiceDate { get; set; }
    public Guid StoreId { get; set; }
    public Guid WaiterId { get; set; }
    public decimal Amount { get; set; }
    public DateTime? TipDate { get; set; }
    public bool IsTipped { get; set; }
    [JsonIgnore]
    public string? QrCode { get; set; }
    public string? Currency { get; set; }

    public string[] Roles => new[] { Admin, Write, InvoicesOperationClaims.Create };

    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, CustomResponseDto<CreatedInvoiceResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly InvoiceBusinessRules _invoiceBusinessRules;

        public CreateInvoiceCommandHandler(IMapper mapper, IInvoiceRepository invoiceRepository,
                                         InvoiceBusinessRules invoiceBusinessRules)
        {
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
            _invoiceBusinessRules = invoiceBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedInvoiceResponse>> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            Invoice invoice = _mapper.Map<Invoice>(request);
            invoice.QrCode = QrCodeHelpers.GenerateQrCode();
            await _invoiceRepository.AddAsync(invoice);

            CreatedInvoiceResponse response = _mapper.Map<CreatedInvoiceResponse>(invoice);
            return CustomResponseDto<CreatedInvoiceResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}