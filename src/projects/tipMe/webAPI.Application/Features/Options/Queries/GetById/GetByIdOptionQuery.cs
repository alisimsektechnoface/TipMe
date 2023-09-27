using Application.Features.Options.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using static Application.Features.Options.Constants.OptionsOperationClaims;

namespace Application.Features.Options.Queries.GetById;

public class GetByIdOptionQuery : IRequest<CustomResponseDto<GetByIdOptionResponse>>
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdOptionQueryHandler : IRequestHandler<GetByIdOptionQuery, CustomResponseDto<GetByIdOptionResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IOptionRepository _optionRepository;
        private readonly OptionBusinessRules _optionBusinessRules;

        public GetByIdOptionQueryHandler(IMapper mapper, IOptionRepository optionRepository, OptionBusinessRules optionBusinessRules)
        {
            _mapper = mapper;
            _optionRepository = optionRepository;
            _optionBusinessRules = optionBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdOptionResponse>> Handle(GetByIdOptionQuery request, CancellationToken cancellationToken)
        {
            Option? option = await _optionRepository.GetAsync(predicate: o => o.Id == request.Id, cancellationToken: cancellationToken);
            await _optionBusinessRules.OptionShouldExistWhenSelected(option);

            GetByIdOptionResponse response = _mapper.Map<GetByIdOptionResponse>(option);

            return CustomResponseDto<GetByIdOptionResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}