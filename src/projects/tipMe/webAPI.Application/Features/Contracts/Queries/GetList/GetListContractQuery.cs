using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Contracts.Queries.GetList;

public class GetListContractQuery : IRequest<CustomResponseDto<GetListResponse<GetListContractListItemDto>>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListContractQueryHandler : IRequestHandler<GetListContractQuery, CustomResponseDto<GetListResponse<GetListContractListItemDto>>>
    {
        private readonly IContractRepository _contractRepository;
        private readonly IMapper _mapper;

        public GetListContractQueryHandler(IContractRepository contractRepository, IMapper mapper)
        {
            _contractRepository = contractRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListContractListItemDto>>> Handle(GetListContractQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Contract> contracts = await _contractRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListContractListItemDto> response = _mapper.Map<GetListResponse<GetListContractListItemDto>>(contracts);
             return CustomResponseDto<GetListResponse<GetListContractListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}