using Application.Features.Tips.Rules;
using Application.Services.Repositories;
using Application.Services.Tips;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using Iyzipay.Model;
using MediatR;
using System.Net;

namespace Application.Features.Tips.Commands.PaymentRequest;

public class PaymentRequestCommand : IRequest<CustomResponseDto<CheckoutFormInitialize>>
{
    public string QrCode { get; set; }
    public decimal TipAmount { get; set; }
    public decimal TaxAmount { get; set; }
    //public string Comment { get; set; }
    //public int Point { get; set; }
    //public List<Guid> Options { get; set; }
    public string RedirectUrl { get; set; }
    public class PaymentRequestCommandHandler : IRequestHandler<PaymentRequestCommand, CustomResponseDto<CheckoutFormInitialize>>
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ITipRepository _tipRepository;
        private readonly IInvoiceOptionRepository _invoiceOptionRepository;
        private readonly ITipsService _tipsService;
        private readonly TipBusinessRules _tipBusinessRules;

        public PaymentRequestCommandHandler(IMapper mapper, IInvoiceOptionRepository invoiceOptionRepository, ITipRepository tipRepository, IInvoiceRepository invoiceRepository, ITipsService tipsService, TipBusinessRules tipBusinessRules)
        {
            _mapper = mapper;
            _tipRepository = tipRepository;
            _invoiceOptionRepository = invoiceOptionRepository;
            _invoiceRepository = invoiceRepository;
            _tipsService = tipsService;
            _tipBusinessRules = tipBusinessRules;
        }

        public async Task<CustomResponseDto<CheckoutFormInitialize>> Handle(PaymentRequestCommand request, CancellationToken cancellationToken)
        {
            Invoice? invoice = await _invoiceRepository.GetAsync(x => x.QrCode == request.QrCode, enableTracking: false, cancellationToken: cancellationToken);
            CheckoutFormInitialize checkoutFormInitialize = await _tipsService.PaymentRequest(request.TipAmount + request.TaxAmount, request.RedirectUrl, invoice);

            if (checkoutFormInitialize?.Status.ToLower() == Status.SUCCESS.ToString())
            {
                Tip? tip = await _tipRepository.GetAsync(x => x.QrCode == invoice.QrCode, enableTracking: false);
                tip.PaymentReference = checkoutFormInitialize.Token;
                //tip.IsCommented = tip.Comment?.Length > 0;
                //tip.CommentDate = tip.Comment?.Length > 0 ? DateTime.Now : null;
                //tip.PaymentDate = DateTime.Now;
                await _tipRepository.UpdateAsync(tip);

                //foreach (var item in request.Options)
                //{
                //    await _invoiceOptionRepository.AddAsync(new() { InvoiceId = invoice.Id, OptionId = item });
                //}
            }

            return CustomResponseDto<CheckoutFormInitialize>.Success((int)HttpStatusCode.OK, checkoutFormInitialize, checkoutFormInitialize.Status.ToLower() == Status.SUCCESS.ToString());
        }
    }
}
