using Application.Features.Waiters.Constants;
using Application.Features.Waiters.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using static Application.Features.Waiters.Constants.WaitersOperationClaims;

namespace Application.Features.Waiters.Commands.Update;

public class UpdateWaiterCommand : IRequest<CustomResponseDto<UpdatedWaiterResponse>>
{
    public Guid Id { get; set; }
    public Guid StoreId { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; }

    public string[] Roles => new[] { Admin, Write, WaitersOperationClaims.Update };

    public class UpdateWaiterCommandHandler : IRequestHandler<UpdateWaiterCommand, CustomResponseDto<UpdatedWaiterResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IWaiterRepository _waiterRepository;
        private readonly WaiterBusinessRules _waiterBusinessRules;

        public UpdateWaiterCommandHandler(IMapper mapper, IWaiterRepository waiterRepository,
                                         WaiterBusinessRules waiterBusinessRules)
        {
            _mapper = mapper;
            _waiterRepository = waiterRepository;
            _waiterBusinessRules = waiterBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedWaiterResponse>> Handle(UpdateWaiterCommand request, CancellationToken cancellationToken)
        {
            Waiter? waiter = await _waiterRepository.GetAsync(predicate: w => w.Id == request.Id, cancellationToken: cancellationToken);
            await _waiterBusinessRules.WaiterShouldExistWhenSelected(waiter);
            waiter = _mapper.Map(request, waiter);

            await _waiterRepository.UpdateAsync(waiter!);

            UpdatedWaiterResponse response = _mapper.Map<UpdatedWaiterResponse>(waiter);

            return CustomResponseDto<UpdatedWaiterResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}