using Application.Features.Waiters.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Application.Features.Waiters.Constants.WaitersOperationClaims;

namespace Application.Features.Waiters.Queries.GetById;

public class GetByIdWaiterQuery : IRequest<CustomResponseDto<GetByIdWaiterResponse>>
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdWaiterQueryHandler : IRequestHandler<GetByIdWaiterQuery, CustomResponseDto<GetByIdWaiterResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IWaiterRepository _waiterRepository;
        private readonly WaiterBusinessRules _waiterBusinessRules;

        public GetByIdWaiterQueryHandler(IMapper mapper, IWaiterRepository waiterRepository, WaiterBusinessRules waiterBusinessRules)
        {
            _mapper = mapper;
            _waiterRepository = waiterRepository;
            _waiterBusinessRules = waiterBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdWaiterResponse>> Handle(GetByIdWaiterQuery request, CancellationToken cancellationToken)
        {
            Waiter? waiter = await _waiterRepository.GetAsync(predicate: w => w.Id == request.Id, include: i => i.Include(x => x.Store), cancellationToken: cancellationToken);
            await _waiterBusinessRules.WaiterShouldExistWhenSelected(waiter);

            GetByIdWaiterResponse response = _mapper.Map<GetByIdWaiterResponse>(waiter);

            return CustomResponseDto<GetByIdWaiterResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}