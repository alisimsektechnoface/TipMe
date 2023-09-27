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

namespace Application.Features.InvoiceOptions.Commands.Update;

public class UpdateInvoiceOptionCommand : IRequest<CustomResponseDto<UpdatedInvoiceOptionResponse>>, ISecuredRequest
{
    public Guid Id { get; set; }
    public Guid InvoiceId { get; set; }
    public Guid OptionId { get; set; }

    public string[] Roles => new[] { Admin, Write, InvoiceOptionsOperationClaims.Update };

    public class UpdateInvoiceOptionCommandHandler : IRequestHandler<UpdateInvoiceOptionCommand, CustomResponseDto<UpdatedInvoiceOptionResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceOptionRepository _invoiceOptionRepository;
        private readonly InvoiceOptionBusinessRules _invoiceOptionBusinessRules;

        public UpdateInvoiceOptionCommandHandler(IMapper mapper, IInvoiceOptionRepository invoiceOptionRepository,
                                         InvoiceOptionBusinessRules invoiceOptionBusinessRules)
        {
            _mapper = mapper;
            _invoiceOptionRepository = invoiceOptionRepository;
            _invoiceOptionBusinessRules = invoiceOptionBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedInvoiceOptionResponse>> Handle(UpdateInvoiceOptionCommand request, CancellationToken cancellationToken)
        {
            InvoiceOption? invoiceOption = await _invoiceOptionRepository.GetAsync(predicate: io => io.Id == request.Id, cancellationToken: cancellationToken);
            await _invoiceOptionBusinessRules.InvoiceOptionShouldExistWhenSelected(invoiceOption);
            invoiceOption = _mapper.Map(request, invoiceOption);

            await _invoiceOptionRepository.UpdateAsync(invoiceOption!);

            UpdatedInvoiceOptionResponse response = _mapper.Map<UpdatedInvoiceOptionResponse>(invoiceOption);

          return CustomResponseDto<UpdatedInvoiceOptionResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}