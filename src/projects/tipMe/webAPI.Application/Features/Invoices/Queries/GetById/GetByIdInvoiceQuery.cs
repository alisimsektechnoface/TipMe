using Application.Features.Invoices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using static Application.Features.Invoices.Constants.InvoicesOperationClaims;

namespace Application.Features.Invoices.Queries.GetById;

public class GetByIdInvoiceQuery : IRequest<CustomResponseDto<GetByIdInvoiceResponse>>
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdInvoiceQueryHandler : IRequestHandler<GetByIdInvoiceQuery, CustomResponseDto<GetByIdInvoiceResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly InvoiceBusinessRules _invoiceBusinessRules;

        public GetByIdInvoiceQueryHandler(IMapper mapper, IInvoiceRepository invoiceRepository, InvoiceBusinessRules invoiceBusinessRules)
        {
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
            _invoiceBusinessRules = invoiceBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdInvoiceResponse>> Handle(GetByIdInvoiceQuery request, CancellationToken cancellationToken)
        {
            Invoice? invoice = await _invoiceRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            await _invoiceBusinessRules.InvoiceShouldExistWhenSelected(invoice);

            GetByIdInvoiceResponse response = _mapper.Map<GetByIdInvoiceResponse>(invoice);

            return CustomResponseDto<GetByIdInvoiceResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}