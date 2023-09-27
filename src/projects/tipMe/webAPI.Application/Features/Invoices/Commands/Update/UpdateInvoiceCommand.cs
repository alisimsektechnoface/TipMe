using Application.Features.Invoices.Constants;
using Application.Features.Invoices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using System.Text.Json.Serialization;
using static Application.Features.Invoices.Constants.InvoicesOperationClaims;

namespace Application.Features.Invoices.Commands.Update;

public class UpdateInvoiceCommand : IRequest<CustomResponseDto<UpdatedInvoiceResponse>>
{
    public Guid Id { get; set; }
    public DateTime InvoiceDate { get; set; }
    public Guid StoreId { get; set; }
    public Guid WaiterId { get; set; }
    public decimal Amount { get; set; }
    public DateTime TipDate { get; set; }
    public bool IsTipped { get; set; }
    [JsonIgnore]
    public string QrCode { get; set; }
    public string Currency { get; set; }

    public string[] Roles => new[] { Admin, Write, InvoicesOperationClaims.Update };

    public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, CustomResponseDto<UpdatedInvoiceResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly InvoiceBusinessRules _invoiceBusinessRules;

        public UpdateInvoiceCommandHandler(IMapper mapper, IInvoiceRepository invoiceRepository,
                                         InvoiceBusinessRules invoiceBusinessRules)
        {
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
            _invoiceBusinessRules = invoiceBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedInvoiceResponse>> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            Invoice? invoice = await _invoiceRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            await _invoiceBusinessRules.InvoiceShouldExistWhenSelected(invoice);
            invoice = _mapper.Map(request, invoice);

            await _invoiceRepository.UpdateAsync(invoice!);

            UpdatedInvoiceResponse response = _mapper.Map<UpdatedInvoiceResponse>(invoice);

            return CustomResponseDto<UpdatedInvoiceResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}