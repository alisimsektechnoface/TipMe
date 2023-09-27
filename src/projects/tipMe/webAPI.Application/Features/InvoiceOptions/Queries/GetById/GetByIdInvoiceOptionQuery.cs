using Application.Features.InvoiceOptions.Constants;
using Application.Features.InvoiceOptions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.InvoiceOptions.Constants.InvoiceOptionsOperationClaims;

namespace Application.Features.InvoiceOptions.Queries.GetById;

public class GetByIdInvoiceOptionQuery : IRequest<CustomResponseDto<GetByIdInvoiceOptionResponse>>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdInvoiceOptionQueryHandler : IRequestHandler<GetByIdInvoiceOptionQuery, CustomResponseDto<GetByIdInvoiceOptionResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceOptionRepository _invoiceOptionRepository;
        private readonly InvoiceOptionBusinessRules _invoiceOptionBusinessRules;

        public GetByIdInvoiceOptionQueryHandler(IMapper mapper, IInvoiceOptionRepository invoiceOptionRepository, InvoiceOptionBusinessRules invoiceOptionBusinessRules)
        {
            _mapper = mapper;
            _invoiceOptionRepository = invoiceOptionRepository;
            _invoiceOptionBusinessRules = invoiceOptionBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdInvoiceOptionResponse>> Handle(GetByIdInvoiceOptionQuery request, CancellationToken cancellationToken)
        {
            InvoiceOption? invoiceOption = await _invoiceOptionRepository.GetAsync(predicate: io => io.Id == request.Id, cancellationToken: cancellationToken);
            await _invoiceOptionBusinessRules.InvoiceOptionShouldExistWhenSelected(invoiceOption);

            GetByIdInvoiceOptionResponse response = _mapper.Map<GetByIdInvoiceOptionResponse>(invoiceOption);

          return CustomResponseDto<GetByIdInvoiceOptionResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}