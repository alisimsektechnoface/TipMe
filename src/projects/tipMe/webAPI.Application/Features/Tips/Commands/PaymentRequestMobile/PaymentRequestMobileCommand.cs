using Application.Features.Tips.Rules;
using Application.Services.Repositories;
using Application.Services.Tips;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;

namespace Application.Features.Tips.Commands.PaymentRequestMobile;

public class PaymentRequestMobileCommand : IRequest<CustomResponseDto<PaymentRequestMobileResponse>>
{
    public string QrCode { get; set; }
    public decimal TipAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public class PaymentRequestMobileCommandHandler : IRequestHandler<PaymentRequestMobileCommand, CustomResponseDto<PaymentRequestMobileResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ITipRepository _tipRepository;
        private readonly IInvoiceOptionRepository _invoiceOptionRepository;
        private readonly ITipsService _tipsService;
        private readonly TipBusinessRules _tipBusinessRules;

        public PaymentRequestMobileCommandHandler(IMapper mapper, IInvoiceOptionRepository invoiceOptionRepository, ITipRepository tipRepository, IInvoiceRepository invoiceRepository, ITipsService tipsService, TipBusinessRules tipBusinessRules)
        {
            _mapper = mapper;
            _tipRepository = tipRepository;
            _invoiceOptionRepository = invoiceOptionRepository;
            _invoiceRepository = invoiceRepository;
            _tipsService = tipsService;
            _tipBusinessRules = tipBusinessRules;
        }

        public async Task<CustomResponseDto<PaymentRequestMobileResponse>> Handle(PaymentRequestMobileCommand request, CancellationToken cancellationToken)
        {
            Invoice? invoice = await _invoiceRepository.GetAsync(x => x.QrCode == request.QrCode, enableTracking: false, cancellationToken: cancellationToken);
            PaymentRequestMobileResponse checkoutFormInitialize = await _tipsService.PaymentRequestMobile(request.TipAmount + request.TaxAmount, invoice);

            //if (checkoutFormInitialize?.Request.Status.ToLower() == Status.SUCCESS.ToString())
            //{
            //    Tip? tip = await _tipRepository.GetAsync(x => x.QrCode == invoice.QrCode, enableTracking: false);
            //    tip.PaymentReference = checkoutFormInitialize.Token;
            //    await _tipRepository.UpdateAsync(tip);
            //}

            return CustomResponseDto<PaymentRequestMobileResponse>.Success((int)HttpStatusCode.OK, checkoutFormInitialize, true);
        }
    }
}
