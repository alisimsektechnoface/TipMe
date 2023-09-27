using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using MediatR;
using System.Net;
using static Application.Features.Waiters.Constants.WaitersOperationClaims;

namespace Application.Features.Waiters.Queries.GetList;

public class GetListWaiterQuery : IRequest<CustomResponseDto<GetListResponse<GetListWaiterListItemDto>>>
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListWaiterQueryHandler : IRequestHandler<GetListWaiterQuery, CustomResponseDto<GetListResponse<GetListWaiterListItemDto>>>
    {
        private readonly IWaiterRepository _waiterRepository;
        private readonly IMapper _mapper;

        public GetListWaiterQueryHandler(IWaiterRepository waiterRepository, IMapper mapper)
        {
            _waiterRepository = waiterRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListWaiterListItemDto>>> Handle(GetListWaiterQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Waiter> waiters = await _waiterRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListWaiterListItemDto> response = _mapper.Map<GetListResponse<GetListWaiterListItemDto>>(waiters);
            return CustomResponseDto<GetListResponse<GetListWaiterListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}