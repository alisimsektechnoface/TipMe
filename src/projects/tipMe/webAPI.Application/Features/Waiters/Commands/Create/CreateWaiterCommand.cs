using Application.Features.Waiters.Constants;
using Application.Features.Waiters.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Waiters.Constants.WaitersOperationClaims;

namespace Application.Features.Waiters.Commands.Create;

public class CreateWaiterCommand : IRequest<CustomResponseDto<CreatedWaiterResponse>>, ISecuredRequest
{
    public Guid StoreId { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; }

    public string[] Roles => new[] { Admin, Write, WaitersOperationClaims.Create };

    public class CreateWaiterCommandHandler : IRequestHandler<CreateWaiterCommand, CustomResponseDto<CreatedWaiterResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IWaiterRepository _waiterRepository;
        private readonly WaiterBusinessRules _waiterBusinessRules;

        public CreateWaiterCommandHandler(IMapper mapper, IWaiterRepository waiterRepository,
                                         WaiterBusinessRules waiterBusinessRules)
        {
            _mapper = mapper;
            _waiterRepository = waiterRepository;
            _waiterBusinessRules = waiterBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedWaiterResponse>> Handle(CreateWaiterCommand request, CancellationToken cancellationToken)
        {
            Waiter waiter = _mapper.Map<Waiter>(request);

            await _waiterRepository.AddAsync(waiter);

            CreatedWaiterResponse response = _mapper.Map<CreatedWaiterResponse>(waiter);
         return CustomResponseDto<CreatedWaiterResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}