using Application.Features.Contracts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.Contracts.Commands.Update;

public class UpdateContractCommand : IRequest<CustomResponseDto<UpdatedContractResponse>>
{
    public Guid Id { get; set; }
    public string Url { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public class UpdateContractCommandHandler : IRequestHandler<UpdateContractCommand, CustomResponseDto<UpdatedContractResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IContractRepository _contractRepository;
        private readonly ContractBusinessRules _contractBusinessRules;

        public UpdateContractCommandHandler(IMapper mapper, IContractRepository contractRepository,
                                         ContractBusinessRules contractBusinessRules)
        {
            _mapper = mapper;
            _contractRepository = contractRepository;
            _contractBusinessRules = contractBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedContractResponse>> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
        {
            Contract? contract = await _contractRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _contractBusinessRules.ContractShouldExistWhenSelected(contract);
            contract = _mapper.Map(request, contract);

            await _contractRepository.UpdateAsync(contract!);

            UpdatedContractResponse response = _mapper.Map<UpdatedContractResponse>(contract);

          return CustomResponseDto<UpdatedContractResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}