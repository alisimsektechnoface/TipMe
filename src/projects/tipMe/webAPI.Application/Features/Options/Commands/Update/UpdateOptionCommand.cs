using Application.Features.Options.Constants;
using Application.Features.Options.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using static Application.Features.Options.Constants.OptionsOperationClaims;

namespace Application.Features.Options.Commands.Update;

public class UpdateOptionCommand : IRequest<CustomResponseDto<UpdatedOptionResponse>>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    public bool IsHappy { get; set; }

    public string[] Roles => new[] { Admin, Write, OptionsOperationClaims.Update };

    public class UpdateOptionCommandHandler : IRequestHandler<UpdateOptionCommand, CustomResponseDto<UpdatedOptionResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IOptionRepository _optionRepository;
        private readonly OptionBusinessRules _optionBusinessRules;

        public UpdateOptionCommandHandler(IMapper mapper, IOptionRepository optionRepository,
                                         OptionBusinessRules optionBusinessRules)
        {
            _mapper = mapper;
            _optionRepository = optionRepository;
            _optionBusinessRules = optionBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedOptionResponse>> Handle(UpdateOptionCommand request, CancellationToken cancellationToken)
        {
            Option? option = await _optionRepository.GetAsync(predicate: o => o.Id == request.Id, cancellationToken: cancellationToken);
            await _optionBusinessRules.OptionShouldExistWhenSelected(option);
            option = _mapper.Map(request, option);

            await _optionRepository.UpdateAsync(option!);

            UpdatedOptionResponse response = _mapper.Map<UpdatedOptionResponse>(option);

            return CustomResponseDto<UpdatedOptionResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}