using Application.Features.Tips.Rules;
using Application.Services.Repositories;
using Application.Services.Tips;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Iyzipay.Model;
using MediatR;
using System.Net;

namespace Application.Features.Tips.Commands.PaymentResult;

public class PaymentResultCommand : IRequest<CustomResponseDto<CheckoutForm>>
{
    public string Token { get; set; }
    public class PaymentResultCommandHandler : IRequestHandler<PaymentResultCommand, CustomResponseDto<CheckoutForm>>
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ITipRepository _tipRepository;
        private readonly ITipsService _tipsService;
        private readonly TipBusinessRules _tipBusinessRules;

        public PaymentResultCommandHandler(IMapper mapper, ITipRepository tipRepository, IInvoiceRepository invoiceRepository, ITipsService tipsService, TipBusinessRules tipBusinessRules)
        {
            _mapper = mapper;
            _tipRepository = tipRepository;
            _invoiceRepository = invoiceRepository;
            _tipsService = tipsService;
            _tipBusinessRules = tipBusinessRules;
        }

        public async Task<CustomResponseDto<CheckoutForm>> Handle(PaymentResultCommand request, CancellationToken cancellationToken)
        {
            CheckoutForm checkoutForm = await _tipsService.PaymentResultToken(request.Token);

            Tip? tipEx = await _tipRepository.GetAsync(x => x.PaymentReference == request.Token, enableTracking: false);

            if (tipEx.QrCode == "A3E96248-C0DE-4CE7-889E-9246E868CB90-0574A69D-3C65-4409-8166-3F7CE90153EA")
                return CustomResponseDto<CheckoutForm>.Success((int)HttpStatusCode.OK, checkoutForm, checkoutForm?.PaymentStatus?.ToLower() == Status.SUCCESS.ToString());

            if (checkoutForm?.PaymentStatus?.ToLower() == Status.SUCCESS.ToString())
            {
                Tip? tip = await _tipRepository.GetAsync(x => x.PaymentReference == request.Token, enableTracking: false);
                tip.IsTipped = true;
                tip.PaymentDate = DateTime.Now;
                await _tipRepository.UpdateAsync(tip);

                Invoice? invoice = await _invoiceRepository.GetAsync(x => x.QrCode == tip.QrCode, enableTracking: false, cancellationToken: cancellationToken);
                invoice.IsTipped = true;
                invoice.TipDate = DateTime.Now;
                await _invoiceRepository.UpdateAsync(invoice);

            }
            //else
            //  throw new BusinessException(TipsBusinessMessages.TipNotExists);

            return CustomResponseDto<CheckoutForm>.Success((int)HttpStatusCode.OK, checkoutForm, checkoutForm.PaymentStatus == Status.SUCCESS.ToString());
        }
    }
}
