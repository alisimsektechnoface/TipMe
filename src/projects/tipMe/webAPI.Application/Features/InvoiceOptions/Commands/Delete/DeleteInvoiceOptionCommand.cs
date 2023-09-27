using Application.Features.InvoiceOptions.Constants;
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

namespace Application.Features.InvoiceOptions.Commands.Delete;

public class DeleteInvoiceOptionCommand : IRequest<CustomResponseDto<DeletedInvoiceOptionResponse>>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, InvoiceOptionsOperationClaims.Delete };

    public class DeleteInvoiceOptionCommandHandler : IRequestHandler<DeleteInvoiceOptionCommand, CustomResponseDto<DeletedInvoiceOptionResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceOptionRepository _invoiceOptionRepository;
        private readonly InvoiceOptionBusinessRules _invoiceOptionBusinessRules;

        public DeleteInvoiceOptionCommandHandler(IMapper mapper, IInvoiceOptionRepository invoiceOptionRepository,
                                         InvoiceOptionBusinessRules invoiceOptionBusinessRules)
        {
            _mapper = mapper;
            _invoiceOptionRepository = invoiceOptionRepository;
            _invoiceOptionBusinessRules = invoiceOptionBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedInvoiceOptionResponse>> Handle(DeleteInvoiceOptionCommand request, CancellationToken cancellationToken)
        {
            InvoiceOption? invoiceOption = await _invoiceOptionRepository.GetAsync(predicate: io => io.Id == request.Id, cancellationToken: cancellationToken);
            await _invoiceOptionBusinessRules.InvoiceOptionShouldExistWhenSelected(invoiceOption);

            await _invoiceOptionRepository.DeleteAsync(invoiceOption!);

            DeletedInvoiceOptionResponse response = _mapper.Map<DeletedInvoiceOptionResponse>(invoiceOption);

             return CustomResponseDto<DeletedInvoiceOptionResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}