using Application.Features.Contracts.Constants;
using Application.Features.Contracts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.Contracts.Commands.Delete;

public class DeleteContractCommand : IRequest<CustomResponseDto<DeletedContractResponse>>
{
    public Guid Id { get; set; }

    public class DeleteContractCommandHandler : IRequestHandler<DeleteContractCommand, CustomResponseDto<DeletedContractResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IContractRepository _contractRepository;
        private readonly ContractBusinessRules _contractBusinessRules;

        public DeleteContractCommandHandler(IMapper mapper, IContractRepository contractRepository,
                                         ContractBusinessRules contractBusinessRules)
        {
            _mapper = mapper;
            _contractRepository = contractRepository;
            _contractBusinessRules = contractBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedContractResponse>> Handle(DeleteContractCommand request, CancellationToken cancellationToken)
        {
            Contract? contract = await _contractRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _contractBusinessRules.ContractShouldExistWhenSelected(contract);

            await _contractRepository.DeleteAsync(contract!);

            DeletedContractResponse response = _mapper.Map<DeletedContractResponse>(contract);

             return CustomResponseDto<DeletedContractResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}