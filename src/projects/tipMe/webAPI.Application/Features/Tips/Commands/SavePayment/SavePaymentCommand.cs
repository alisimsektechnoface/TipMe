using Application.Features.Tips.Rules;
using Application.Services.Repositories;
using Application.Services.Tips;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using MediatR;
using System.Net;

namespace Application.Features.Tips.Commands.SavePayment;

public class SavePaymentCommand : IRequest<CustomResponseDto<SavePaymentResponse>>
{

    public class SavePaymentCommandHandler : IRequestHandler<SavePaymentCommand, CustomResponseDto<SavePaymentResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ITipRepository _tipRepository;
        private readonly ITipsService _tipsService;
        private readonly TipBusinessRules _tipBusinessRules;


        public SavePaymentCommandHandler(IMapper mapper, ITipRepository tipRepository, IInvoiceRepository invoiceRepository, ITipsService tipsService, TipBusinessRules tipBusinessRules)
        {
            _mapper = mapper;
            _tipRepository = tipRepository;
            _invoiceRepository = invoiceRepository;
            _tipsService = tipsService;
            _tipBusinessRules = tipBusinessRules;
        }

        public async Task<CustomResponseDto<SavePaymentResponse>> Handle(SavePaymentCommand request, CancellationToken cancellationToken)
        {
            SavePaymentResponse response = _mapper.Map<SavePaymentResponse>(null);

            return CustomResponseDto<SavePaymentResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}
