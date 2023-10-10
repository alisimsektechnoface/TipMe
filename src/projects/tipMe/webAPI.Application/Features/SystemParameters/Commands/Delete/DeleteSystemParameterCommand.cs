using Application.Features.SystemParameters.Constants;
using Application.Features.SystemParameters.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.SystemParameters.Commands.Delete;

public class DeleteSystemParameterCommand : IRequest<CustomResponseDto<DeletedSystemParameterResponse>>
{
    public Guid Id { get; set; }

    public class DeleteSystemParameterCommandHandler : IRequestHandler<DeleteSystemParameterCommand, CustomResponseDto<DeletedSystemParameterResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ISystemParameterRepository _systemParameterRepository;
        private readonly SystemParameterBusinessRules _systemParameterBusinessRules;

        public DeleteSystemParameterCommandHandler(IMapper mapper, ISystemParameterRepository systemParameterRepository,
                                         SystemParameterBusinessRules systemParameterBusinessRules)
        {
            _mapper = mapper;
            _systemParameterRepository = systemParameterRepository;
            _systemParameterBusinessRules = systemParameterBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedSystemParameterResponse>> Handle(DeleteSystemParameterCommand request, CancellationToken cancellationToken)
        {
            SystemParameter? systemParameter = await _systemParameterRepository.GetAsync(predicate: sp => sp.Id == request.Id, cancellationToken: cancellationToken);
            await _systemParameterBusinessRules.SystemParameterShouldExistWhenSelected(systemParameter);

            await _systemParameterRepository.DeleteAsync(systemParameter!);

            DeletedSystemParameterResponse response = _mapper.Map<DeletedSystemParameterResponse>(systemParameter);

             return CustomResponseDto<DeletedSystemParameterResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}