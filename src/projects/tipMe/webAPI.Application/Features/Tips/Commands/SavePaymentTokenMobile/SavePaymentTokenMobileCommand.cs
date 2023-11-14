using Application.Features.Tips.Rules;
using Application.Services.Tips;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using MediatR;
using System.Net;

namespace Application.Features.Tips.Commands.SavePaymentTokenMobile;

public class SavePaymentTokenMobileCommand : IRequest<CustomResponseDto<bool>>
{
    public string QrCode { get; set; }
    public string Token { get; set; }
    public class SavePaymentTokenMobileCommandHandler : IRequestHandler<SavePaymentTokenMobileCommand, CustomResponseDto<bool>>
    {
        private readonly IMapper _mapper;
        private readonly ITipsService _tipsService;
        private readonly TipBusinessRules _tipBusinessRules;

        public SavePaymentTokenMobileCommandHandler(IMapper mapper, ITipsService tipsService, TipBusinessRules tipBusinessRules)
        {
            _mapper = mapper;
            _tipsService = tipsService;
            _tipBusinessRules = tipBusinessRules;
        }

        public async Task<CustomResponseDto<bool>> Handle(SavePaymentTokenMobileCommand request, CancellationToken cancellationToken)
        {
            bool resut = await _tipsService.SavePaymentTokenMobile(request.QrCode, request.Token);

            return CustomResponseDto<bool>.Success((int)HttpStatusCode.OK, resut, true);
        }
    }
}
