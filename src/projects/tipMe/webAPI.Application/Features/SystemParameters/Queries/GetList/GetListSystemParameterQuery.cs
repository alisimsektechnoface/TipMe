using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SystemParameters.Queries.GetList;

public class GetListSystemParameterQuery : IRequest<CustomResponseDto<GetListResponse<GetListSystemParameterListItemDto>>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSystemParameterQueryHandler : IRequestHandler<GetListSystemParameterQuery, CustomResponseDto<GetListResponse<GetListSystemParameterListItemDto>>>
    {
        private readonly ISystemParameterRepository _systemParameterRepository;
        private readonly IMapper _mapper;

        public GetListSystemParameterQueryHandler(ISystemParameterRepository systemParameterRepository, IMapper mapper)
        {
            _systemParameterRepository = systemParameterRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetListResponse<GetListSystemParameterListItemDto>>> Handle(GetListSystemParameterQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SystemParameter> systemParameters = await _systemParameterRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSystemParameterListItemDto> response = _mapper.Map<GetListResponse<GetListSystemParameterListItemDto>>(systemParameters);
             return CustomResponseDto<GetListResponse<GetListSystemParameterListItemDto>>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}