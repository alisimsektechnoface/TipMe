using Application.Features.Invoices.Constants;
using Application.Features.Invoices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using static Application.Features.Invoices.Constants.InvoicesOperationClaims;

namespace Application.Features.Invoices.Commands.Delete;

public class DeleteInvoiceCommand : IRequest<CustomResponseDto<DeletedInvoiceResponse>>
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, InvoicesOperationClaims.Delete };

    public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, CustomResponseDto<DeletedInvoiceResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly InvoiceBusinessRules _invoiceBusinessRules;

        public DeleteInvoiceCommandHandler(IMapper mapper, IInvoiceRepository invoiceRepository,
                                         InvoiceBusinessRules invoiceBusinessRules)
        {
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
            _invoiceBusinessRules = invoiceBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedInvoiceResponse>> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            Invoice? invoice = await _invoiceRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            await _invoiceBusinessRules.InvoiceShouldExistWhenSelected(invoice);

            await _invoiceRepository.DeleteAsync(invoice!);

            DeletedInvoiceResponse response = _mapper.Map<DeletedInvoiceResponse>(invoice);

            return CustomResponseDto<DeletedInvoiceResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}