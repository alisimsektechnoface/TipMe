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

namespace Application.Features.InvoiceOptions.Commands.Create;

public class CreateInvoiceOptionCommand : IRequest<CustomResponseDto<CreatedInvoiceOptionResponse>>, ISecuredRequest
{
    public Guid InvoiceId { get; set; }
    public Guid OptionId { get; set; }

    public string[] Roles => new[] { Admin, Write, InvoiceOptionsOperationClaims.Create };

    public class CreateInvoiceOptionCommandHandler : IRequestHandler<CreateInvoiceOptionCommand, CustomResponseDto<CreatedInvoiceOptionResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceOptionRepository _invoiceOptionRepository;
        private readonly InvoiceOptionBusinessRules _invoiceOptionBusinessRules;

        public CreateInvoiceOptionCommandHandler(IMapper mapper, IInvoiceOptionRepository invoiceOptionRepository,
                                         InvoiceOptionBusinessRules invoiceOptionBusinessRules)
        {
            _mapper = mapper;
            _invoiceOptionRepository = invoiceOptionRepository;
            _invoiceOptionBusinessRules = invoiceOptionBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedInvoiceOptionResponse>> Handle(CreateInvoiceOptionCommand request, CancellationToken cancellationToken)
        {
            InvoiceOption invoiceOption = _mapper.Map<InvoiceOption>(request);

            await _invoiceOptionRepository.AddAsync(invoiceOption);

            CreatedInvoiceOptionResponse response = _mapper.Map<CreatedInvoiceOptionResponse>(invoiceOption);
         return CustomResponseDto<CreatedInvoiceOptionResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}