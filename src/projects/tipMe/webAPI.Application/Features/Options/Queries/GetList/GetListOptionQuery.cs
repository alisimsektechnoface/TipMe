using Application.Features.Options.Constants;
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
using static Application.Features.Options.Constants.OptionsOperationClaims;

namespace Application.Features.Options.Queries.GetList;

public class GetListOptionQuery : IRequest<CustomResponseDto<GetListResponse<GetListOptionListItemDto>>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListOptionQueryHandler : IRequestHandler<GetListOptionQuery, CustomResponseDto<GetListResponse<GetListOptionListItemDto>>>
    {
        private readonly IOptionRepository _optionRepository;
        private readonly IMapper _mapper;

        public GetListOptionQueryHandler(IOptionRepository optionRepository, IMapper mapper)
        {
            _optionRepository = optionRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListOptionListItemDto>>> Handle(GetListOptionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Option> options = await _optionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListOptionListItemDto> response = _mapper.Map<GetListResponse<GetListOptionListItemDto>>(options);
             return CustomResponseDto<GetListResponse<GetListOptionListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}