using Application.Features.Options.Queries.GetById;
using Application.Features.Options.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.Features.Options.Queries.GetOptionsWithGroup;

public class GetOptionsWithGroupQuery : IRequest<CustomResponseDto<GetOptionsWithGroupResponse>>
{

    public class GetOptionsWithGroupQueryHandler : IRequestHandler<GetOptionsWithGroupQuery, CustomResponseDto<GetOptionsWithGroupResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IOptionRepository _optionRepository;
        private readonly OptionBusinessRules _optionBusinessRules;

        public GetOptionsWithGroupQueryHandler(IMapper mapper, IOptionRepository optionRepository, OptionBusinessRules optionBusinessRules)
        {
            _mapper = mapper;
            _optionRepository = optionRepository;
            _optionBusinessRules = optionBusinessRules;
        }

        public async Task<CustomResponseDto<GetOptionsWithGroupResponse>> Handle(GetOptionsWithGroupQuery request, CancellationToken cancellationToken)
        {
            var groupedItems = await _optionRepository.Query().GroupBy(item => item.IsHappy).ToListAsync();
            GetOptionsWithGroupResponse response = new GetOptionsWithGroupResponse();
            foreach (var group in groupedItems)
            {
                if (group.Key)
                {
                    response.Happy = _mapper.Map<List<GetByIdOptionResponse>>(group.ToList());
                }
                else
                {
                    response.Unhappy = _mapper.Map<List<GetByIdOptionResponse>>(group.ToList());
                }
            }
            return CustomResponseDto<GetOptionsWithGroupResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}
