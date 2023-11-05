using Application.Features.Tips.Rules;
using Application.Services.Repositories;
using Application.Services.Tips;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Iyzipay.Model;
using MediatR;
using System.Net;

namespace Application.Features.Tips.Commands.PaymentRequestWithCard;

public class PaymentRequestWithCardCommand : IRequest<CustomResponseDto<Payment>>
{
    public PaymentRequestWithCardRequest Request { get; set; }
    public class PaymentRequestWithCardCommandHandler : IRequestHandler<PaymentRequestWithCardCommand, CustomResponseDto<Payment>>
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ITipRepository _tipRepository;
        private readonly IInvoiceOptionRepository _invoiceOptionRepository;
        private readonly ITipsService _tipsService;
        private readonly TipBusinessRules _tipBusinessRules;

        public PaymentRequestWithCardCommandHandler(IMapper mapper, IInvoiceOptionRepository invoiceOptionRepository, ITipRepository tipRepository, IInvoiceRepository invoiceRepository, ITipsService tipsService, TipBusinessRules tipBusinessRules)
        {
            _mapper = mapper;
            _tipRepository = tipRepository;
            _invoiceOptionRepository = invoiceOptionRepository;
            _invoiceRepository = invoiceRepository;
            _tipsService = tipsService;
            _tipBusinessRules = tipBusinessRules;
        }

        public async Task<CustomResponseDto<Payment>> Handle(PaymentRequestWithCardCommand request, CancellationToken cancellationToken)
        {
            Invoice? invoice = await _invoiceRepository.GetAsync(x => x.QrCode == request.Request.QrCode, enableTracking: false, cancellationToken: cancellationToken);
            Payment payment = await _tipsService.PaymentRequestWithCart(request.Request, invoice);

            if (payment?.Status.ToLower() == Status.SUCCESS.ToString())
            {
                Tip? tip = await _tipRepository.GetAsync(x => x.QrCode == invoice!.QrCode, enableTracking: false);
                tip.PaymentReference = payment.PaymentId;
                tip.IsTipped = true;
                tip.PaymentDate = DateTime.Now;
                await _tipRepository.UpdateAsync(tip);

                invoice.IsTipped = true;
                invoice.TipDate = DateTime.Now;
                await _invoiceRepository.UpdateAsync(invoice);

            }

            return CustomResponseDto<Payment>.Success((int)HttpStatusCode.OK, payment, payment.Status.ToLower() == Status.SUCCESS.ToString());
        }
    }
}
