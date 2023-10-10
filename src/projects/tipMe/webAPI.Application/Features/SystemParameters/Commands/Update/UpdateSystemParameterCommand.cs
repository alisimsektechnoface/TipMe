using Application.Features.SystemParameters.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.SystemParameters.Commands.Update;

public class UpdateSystemParameterCommand : IRequest<CustomResponseDto<UpdatedSystemParameterResponse>>
{
    public Guid Id { get; set; }
    public string ParameterKey { get; set; }
    public string ParameterValue { get; set; }
    public string? SampleValue { get; set; }
    public string? Description { get; set; }

    public class UpdateSystemParameterCommandHandler : IRequestHandler<UpdateSystemParameterCommand, CustomResponseDto<UpdatedSystemParameterResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ISystemParameterRepository _systemParameterRepository;
        private readonly SystemParameterBusinessRules _systemParameterBusinessRules;

        public UpdateSystemParameterCommandHandler(IMapper mapper, ISystemParameterRepository systemParameterRepository,
                                         SystemParameterBusinessRules systemParameterBusinessRules)
        {
            _mapper = mapper;
            _systemParameterRepository = systemParameterRepository;
            _systemParameterBusinessRules = systemParameterBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedSystemParameterResponse>> Handle(UpdateSystemParameterCommand request, CancellationToken cancellationToken)
        {
            SystemParameter? systemParameter = await _systemParameterRepository.GetAsync(predicate: sp => sp.Id == request.Id, cancellationToken: cancellationToken);
            await _systemParameterBusinessRules.SystemParameterShouldExistWhenSelected(systemParameter);
            systemParameter = _mapper.Map(request, systemParameter);

            await _systemParameterRepository.UpdateAsync(systemParameter!);

            UpdatedSystemParameterResponse response = _mapper.Map<UpdatedSystemParameterResponse>(systemParameter);

          return CustomResponseDto<UpdatedSystemParameterResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}