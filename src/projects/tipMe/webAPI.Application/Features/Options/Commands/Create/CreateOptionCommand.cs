using Application.Features.Options.Constants;
using Application.Features.Options.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using static Application.Features.Options.Constants.OptionsOperationClaims;

namespace Application.Features.Options.Commands.Create;

public class CreateOptionCommand : IRequest<CustomResponseDto<CreatedOptionResponse>>
{
    public string Name { get; set; }
    public string Icon { get; set; }
    public bool IsHappy { get; set; }

    public string[] Roles => new[] { Admin, Write, OptionsOperationClaims.Create };

    public class CreateOptionCommandHandler : IRequestHandler<CreateOptionCommand, CustomResponseDto<CreatedOptionResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IOptionRepository _optionRepository;
        private readonly OptionBusinessRules _optionBusinessRules;

        public CreateOptionCommandHandler(IMapper mapper, IOptionRepository optionRepository,
                                         OptionBusinessRules optionBusinessRules)
        {
            _mapper = mapper;
            _optionRepository = optionRepository;
            _optionBusinessRules = optionBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedOptionResponse>> Handle(CreateOptionCommand request, CancellationToken cancellationToken)
        {
            Option option = _mapper.Map<Option>(request);

            await _optionRepository.AddAsync(option);

            CreatedOptionResponse response = _mapper.Map<CreatedOptionResponse>(option);
            return CustomResponseDto<CreatedOptionResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}