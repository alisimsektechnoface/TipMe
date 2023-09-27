using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using MediatR;
using System.Net;
using static Application.Features.Tips.Constants.TipsOperationClaims;

namespace Application.Features.Tips.Queries.GetList;

public class GetListTipQuery : IRequest<CustomResponseDto<GetListResponse<GetListTipListItemDto>>>
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListTipQueryHandler : IRequestHandler<GetListTipQuery, CustomResponseDto<GetListResponse<GetListTipListItemDto>>>
    {
        private readonly ITipRepository _tipRepository;
        private readonly IMapper _mapper;

        public GetListTipQueryHandler(ITipRepository tipRepository, IMapper mapper)
        {
            _tipRepository = tipRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListTipListItemDto>>> Handle(GetListTipQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Tip> tips = await _tipRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTipListItemDto> response = _mapper.Map<GetListResponse<GetListTipListItemDto>>(tips);
            return CustomResponseDto<GetListResponse<GetListTipListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}