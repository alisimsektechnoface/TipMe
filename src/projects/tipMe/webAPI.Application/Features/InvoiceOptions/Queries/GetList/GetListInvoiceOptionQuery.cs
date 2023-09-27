using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using MediatR;
using System.Net;
using static Application.Features.InvoiceOptions.Constants.InvoiceOptionsOperationClaims;

namespace Application.Features.InvoiceOptions.Queries.GetList;

public class GetListInvoiceOptionQuery : IRequest<CustomResponseDto<GetListResponse<GetListInvoiceOptionListItemDto>>>
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListInvoiceOptionQueryHandler : IRequestHandler<GetListInvoiceOptionQuery, CustomResponseDto<GetListResponse<GetListInvoiceOptionListItemDto>>>
    {
        private readonly IInvoiceOptionRepository _invoiceOptionRepository;
        private readonly IMapper _mapper;

        public GetListInvoiceOptionQueryHandler(IInvoiceOptionRepository invoiceOptionRepository, IMapper mapper)
        {
            _invoiceOptionRepository = invoiceOptionRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListInvoiceOptionListItemDto>>> Handle(GetListInvoiceOptionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<InvoiceOption> invoiceOptions = await _invoiceOptionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListInvoiceOptionListItemDto> response = _mapper.Map<GetListResponse<GetListInvoiceOptionListItemDto>>(invoiceOptions);
            return CustomResponseDto<GetListResponse<GetListInvoiceOptionListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}