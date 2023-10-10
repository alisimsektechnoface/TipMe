using Application.Features.SystemParameters.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.SystemParameters.Queries.GetById;

public class GetByIdSystemParameterQuery : IRequest<CustomResponseDto<GetByIdSystemParameterResponse>>
{
    public Guid Id { get; set; }

    public class GetByIdSystemParameterQueryHandler : IRequestHandler<GetByIdSystemParameterQuery, CustomResponseDto<GetByIdSystemParameterResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ISystemParameterRepository _systemParameterRepository;
        private readonly SystemParameterBusinessRules _systemParameterBusinessRules;

        public GetByIdSystemParameterQueryHandler(IMapper mapper, ISystemParameterRepository systemParameterRepository, SystemParameterBusinessRules systemParameterBusinessRules)
        {
            _mapper = mapper;
            _systemParameterRepository = systemParameterRepository;
            _systemParameterBusinessRules = systemParameterBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdSystemParameterResponse>> Handle(GetByIdSystemParameterQuery request, CancellationToken cancellationToken)
        {
            SystemParameter? systemParameter = await _systemParameterRepository.GetAsync(predicate: sp => sp.Id == request.Id, cancellationToken: cancellationToken);
            await _systemParameterBusinessRules.SystemParameterShouldExistWhenSelected(systemParameter);

            GetByIdSystemParameterResponse response = _mapper.Map<GetByIdSystemParameterResponse>(systemParameter);

          return CustomResponseDto<GetByIdSystemParameterResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}