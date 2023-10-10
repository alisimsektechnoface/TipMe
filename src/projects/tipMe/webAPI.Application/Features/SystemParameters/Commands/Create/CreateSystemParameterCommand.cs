using Application.Features.SystemParameters.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.SystemParameters.Commands.Create;

public class CreateSystemParameterCommand : IRequest<CustomResponseDto<CreatedSystemParameterResponse>>
{
    public string ParameterKey { get; set; }
    public string ParameterValue { get; set; }
    public string? SampleValue { get; set; }
    public string? Description { get; set; }

    public class CreateSystemParameterCommandHandler : IRequestHandler<CreateSystemParameterCommand, CustomResponseDto<CreatedSystemParameterResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ISystemParameterRepository _systemParameterRepository;
        private readonly SystemParameterBusinessRules _systemParameterBusinessRules;

        public CreateSystemParameterCommandHandler(IMapper mapper, ISystemParameterRepository systemParameterRepository,
                                         SystemParameterBusinessRules systemParameterBusinessRules)
        {
            _mapper = mapper;
            _systemParameterRepository = systemParameterRepository;
            _systemParameterBusinessRules = systemParameterBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedSystemParameterResponse>> Handle(CreateSystemParameterCommand request, CancellationToken cancellationToken)
        {
            SystemParameter systemParameter = _mapper.Map<SystemParameter>(request);

            await _systemParameterRepository.AddAsync(systemParameter);

            CreatedSystemParameterResponse response = _mapper.Map<CreatedSystemParameterResponse>(systemParameter);
         return CustomResponseDto<CreatedSystemParameterResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}