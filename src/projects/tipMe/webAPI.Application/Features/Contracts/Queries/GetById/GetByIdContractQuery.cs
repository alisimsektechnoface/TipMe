using Application.Features.Contracts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.Contracts.Queries.GetById;

public class GetByIdContractQuery : IRequest<CustomResponseDto<GetByIdContractResponse>>
{
    public Guid Id { get; set; }

    public class GetByIdContractQueryHandler : IRequestHandler<GetByIdContractQuery, CustomResponseDto<GetByIdContractResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IContractRepository _contractRepository;
        private readonly ContractBusinessRules _contractBusinessRules;

        public GetByIdContractQueryHandler(IMapper mapper, IContractRepository contractRepository, ContractBusinessRules contractBusinessRules)
        {
            _mapper = mapper;
            _contractRepository = contractRepository;
            _contractBusinessRules = contractBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdContractResponse>> Handle(GetByIdContractQuery request, CancellationToken cancellationToken)
        {
            Contract? contract = await _contractRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _contractBusinessRules.ContractShouldExistWhenSelected(contract);

            GetByIdContractResponse response = _mapper.Map<GetByIdContractResponse>(contract);

          return CustomResponseDto<GetByIdContractResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}