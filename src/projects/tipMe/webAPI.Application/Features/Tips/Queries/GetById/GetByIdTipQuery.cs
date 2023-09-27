using Application.Features.Tips.Constants;
using Application.Features.Tips.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Tips.Constants.TipsOperationClaims;

namespace Application.Features.Tips.Queries.GetById;

public class GetByIdTipQuery : IRequest<CustomResponseDto<GetByIdTipResponse>>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdTipQueryHandler : IRequestHandler<GetByIdTipQuery, CustomResponseDto<GetByIdTipResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ITipRepository _tipRepository;
        private readonly TipBusinessRules _tipBusinessRules;

        public GetByIdTipQueryHandler(IMapper mapper, ITipRepository tipRepository, TipBusinessRules tipBusinessRules)
        {
            _mapper = mapper;
            _tipRepository = tipRepository;
            _tipBusinessRules = tipBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdTipResponse>> Handle(GetByIdTipQuery request, CancellationToken cancellationToken)
        {
            Tip? tip = await _tipRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _tipBusinessRules.TipShouldExistWhenSelected(tip);

            GetByIdTipResponse response = _mapper.Map<GetByIdTipResponse>(tip);

          return CustomResponseDto<GetByIdTipResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}