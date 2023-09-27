using Application.Features.Tips.Constants;
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

namespace Application.Features.Tips.Commands.Delete;

public class DeleteTipCommand : IRequest<CustomResponseDto<DeletedTipResponse>>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, TipsOperationClaims.Delete };

    public class DeleteTipCommandHandler : IRequestHandler<DeleteTipCommand, CustomResponseDto<DeletedTipResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ITipRepository _tipRepository;
        private readonly TipBusinessRules _tipBusinessRules;

        public DeleteTipCommandHandler(IMapper mapper, ITipRepository tipRepository,
                                         TipBusinessRules tipBusinessRules)
        {
            _mapper = mapper;
            _tipRepository = tipRepository;
            _tipBusinessRules = tipBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedTipResponse>> Handle(DeleteTipCommand request, CancellationToken cancellationToken)
        {
            Tip? tip = await _tipRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _tipBusinessRules.TipShouldExistWhenSelected(tip);

            await _tipRepository.DeleteAsync(tip!);

            DeletedTipResponse response = _mapper.Map<DeletedTipResponse>(tip);

             return CustomResponseDto<DeletedTipResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}