using Application.Features.Invoices.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Invoices.Constants.InvoicesOperationClaims;

namespace Application.Features.Invoices.Queries.GetList;

public class GetListInvoiceQuery : IRequest<CustomResponseDto<GetListResponse<GetListInvoiceListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListInvoiceQueryHandler : IRequestHandler<GetListInvoiceQuery, CustomResponseDto<GetListResponse<GetListInvoiceListItemDto>>>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public GetListInvoiceQueryHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListInvoiceListItemDto>>> Handle(GetListInvoiceQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Invoice> invoices = await _invoiceRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListInvoiceListItemDto> response = _mapper.Map<GetListResponse<GetListInvoiceListItemDto>>(invoices);
             return CustomResponseDto<GetListResponse<GetListInvoiceListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}