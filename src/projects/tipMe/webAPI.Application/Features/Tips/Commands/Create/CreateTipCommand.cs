using Application.Features.Tips.Constants;
using Application.Features.Tips.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using static Application.Features.Tips.Constants.TipsOperationClaims;

namespace Application.Features.Tips.Commands.Create;

public class CreateTipCommand : IRequest<CustomResponseDto<CreatedTipResponse>>
{
    public DateTime RequestDate { get; set; }
    public string QrCode { get; set; }
    public bool IsTipped { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentReference { get; set; }
    public bool IsCommented { get; set; }
    public string Comment { get; set; }
    public DateTime CommentDate { get; set; }
    public int Point { get; set; }

    public string[] Roles => new[] { Admin, Write, TipsOperationClaims.Create };

    public class CreateTipCommandHandler : IRequestHandler<CreateTipCommand, CustomResponseDto<CreatedTipResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ITipRepository _tipRepository;
        private readonly TipBusinessRules _tipBusinessRules;

        public CreateTipCommandHandler(IMapper mapper, ITipRepository tipRepository,
                                         TipBusinessRules tipBusinessRules)
        {
            _mapper = mapper;
            _tipRepository = tipRepository;
            _tipBusinessRules = tipBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedTipResponse>> Handle(CreateTipCommand request, CancellationToken cancellationToken)
        {
            Tip tip = _mapper.Map<Tip>(request);

            await _tipRepository.AddAsync(tip);

            CreatedTipResponse response = _mapper.Map<CreatedTipResponse>(tip);
            return CustomResponseDto<CreatedTipResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}