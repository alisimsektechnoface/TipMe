using Application.Features.Tips.Constants;
using Application.Features.Tips.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using static Application.Features.Tips.Constants.TipsOperationClaims;

namespace Application.Features.Tips.Commands.Update;

public class UpdateTipCommand : IRequest<CustomResponseDto<UpdatedTipResponse>>
{
    public Guid Id { get; set; }
    public DateTime RequestDate { get; set; }
    public string QrCode { get; set; }
    public decimal? TipAmount { get; set; }
    public bool? IsTipped { get; set; }
    public DateTime? PaymentDate { get; set; }
    public string? PaymentReference { get; set; }
    public bool? IsCommented { get; set; }
    public string? Comment { get; set; }
    public DateTime? CommentDate { get; set; }
    public int? Point { get; set; }

    public string[] Roles => new[] { Admin, Write, TipsOperationClaims.Update };

    public class UpdateTipCommandHandler : IRequestHandler<UpdateTipCommand, CustomResponseDto<UpdatedTipResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ITipRepository _tipRepository;
        private readonly TipBusinessRules _tipBusinessRules;

        public UpdateTipCommandHandler(IMapper mapper, ITipRepository tipRepository,
                                         TipBusinessRules tipBusinessRules)
        {
            _mapper = mapper;
            _tipRepository = tipRepository;
            _tipBusinessRules = tipBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedTipResponse>> Handle(UpdateTipCommand request, CancellationToken cancellationToken)
        {
            Tip? tip = await _tipRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _tipBusinessRules.TipShouldExistWhenSelected(tip);
            tip = _mapper.Map(request, tip);

            await _tipRepository.UpdateAsync(tip!);

            UpdatedTipResponse response = _mapper.Map<UpdatedTipResponse>(tip);

            return CustomResponseDto<UpdatedTipResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}