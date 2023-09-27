using Application.Features.Waiters.Constants;
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

namespace Application.Features.Waiters.Commands.Delete;

public class DeleteWaiterCommand : IRequest<CustomResponseDto<DeletedWaiterResponse>>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, WaitersOperationClaims.Delete };

    public class DeleteWaiterCommandHandler : IRequestHandler<DeleteWaiterCommand, CustomResponseDto<DeletedWaiterResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IWaiterRepository _waiterRepository;
        private readonly WaiterBusinessRules _waiterBusinessRules;

        public DeleteWaiterCommandHandler(IMapper mapper, IWaiterRepository waiterRepository,
                                         WaiterBusinessRules waiterBusinessRules)
        {
            _mapper = mapper;
            _waiterRepository = waiterRepository;
            _waiterBusinessRules = waiterBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedWaiterResponse>> Handle(DeleteWaiterCommand request, CancellationToken cancellationToken)
        {
            Waiter? waiter = await _waiterRepository.GetAsync(predicate: w => w.Id == request.Id, cancellationToken: cancellationToken);
            await _waiterBusinessRules.WaiterShouldExistWhenSelected(waiter);

            await _waiterRepository.DeleteAsync(waiter!);

            DeletedWaiterResponse response = _mapper.Map<DeletedWaiterResponse>(waiter);

             return CustomResponseDto<DeletedWaiterResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}