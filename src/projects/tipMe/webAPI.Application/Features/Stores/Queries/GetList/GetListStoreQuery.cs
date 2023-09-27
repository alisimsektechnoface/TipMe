using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using MediatR;
using System.Net;
using static Application.Features.Stores.Constants.StoresOperationClaims;

namespace Application.Features.Stores.Queries.GetList;

public class GetListStoreQuery : IRequest<CustomResponseDto<GetListResponse<GetListStoreListItemDto>>>
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListStoreQueryHandler : IRequestHandler<GetListStoreQuery, CustomResponseDto<GetListResponse<GetListStoreListItemDto>>>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public GetListStoreQueryHandler(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListStoreListItemDto>>> Handle(GetListStoreQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Store> stores = await _storeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListStoreListItemDto> response = _mapper.Map<GetListResponse<GetListStoreListItemDto>>(stores);
            return CustomResponseDto<GetListResponse<GetListStoreListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}