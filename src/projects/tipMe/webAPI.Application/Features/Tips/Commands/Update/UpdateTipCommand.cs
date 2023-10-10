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
    public string QrCode { get; set; }
    public decimal? TipAmount { get; set; }
    public decimal? TaxAmount { get; set; }
    public string? Comment { get; set; }
    public int? Point { get; set; }
    public List<Guid> Options { get; set; }

    public string[] Roles => new[] { Admin, Write, TipsOperationClaims.Update };

    public class UpdateTipCommandHandler : IRequestHandler<UpdateTipCommand, CustomResponseDto<UpdatedTipResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ITipRepository _tipRepository;
        private readonly IInvoiceOptionRepository _invoiceOptionRepository;
        private readonly TipBusinessRules _tipBusinessRules;

        public UpdateTipCommandHandler(IMapper mapper, ITipRepository tipRepository, IInvoiceOptionRepository invoiceOptionRepository, IInvoiceRepository invoiceRepository,
                                         TipBusinessRules tipBusinessRules)
        {
            _mapper = mapper;
            _invoiceOptionRepository = invoiceOptionRepository;
            _invoiceRepository = invoiceRepository;
            _tipRepository = tipRepository;
            _tipBusinessRules = tipBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedTipResponse>> Handle(UpdateTipCommand request, CancellationToken cancellationToken)
        {
            Tip? tip = await _tipRepository.GetAsync(predicate: t => t.QrCode == request.QrCode, cancellationToken: cancellationToken);
            await _tipBusinessRules.TipShouldExistWhenSelected(tip);
            tip = _mapper.Map(request, tip);
            tip.Point = request.Point;
            tip.Comment = tip.Comment?.Trim();
            tip.IsCommented = tip.Comment?.Length > 0;
            tip.CommentDate = tip.Comment?.Length > 0 ? DateTime.Now : null;
            await _tipRepository.UpdateAsync(tip!);

            Invoice? invoice = await _invoiceRepository.GetAsync(predicate: x => x.QrCode == tip.QrCode, cancellationToken: cancellationToken);

            foreach (var item in request.Options)
            {
                await _invoiceOptionRepository.AddAsync(new() { InvoiceId = invoice.Id, OptionId = item });
            }

            UpdatedTipResponse response = _mapper.Map<UpdatedTipResponse>(tip);

            return CustomResponseDto<UpdatedTipResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}