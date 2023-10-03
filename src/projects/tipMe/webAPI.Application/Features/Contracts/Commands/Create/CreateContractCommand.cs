using Application.Features.Contracts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.Contracts.Commands.Create;

public class CreateContractCommand : IRequest<CustomResponseDto<CreatedContractResponse>>
{
    public string Url { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, CustomResponseDto<CreatedContractResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IContractRepository _contractRepository;
        private readonly ContractBusinessRules _contractBusinessRules;

        public CreateContractCommandHandler(IMapper mapper, IContractRepository contractRepository,
                                         ContractBusinessRules contractBusinessRules)
        {
            _mapper = mapper;
            _contractRepository = contractRepository;
            _contractBusinessRules = contractBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedContractResponse>> Handle(CreateContractCommand request, CancellationToken cancellationToken)
        {
            Contract contract = _mapper.Map<Contract>(request);

            await _contractRepository.AddAsync(contract);

            CreatedContractResponse response = _mapper.Map<CreatedContractResponse>(contract);
         return CustomResponseDto<CreatedContractResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}