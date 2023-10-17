using Application.Features.Stores.Constants;
using Application.Features.Stores.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using static Application.Features.Stores.Constants.StoresOperationClaims;

namespace Application.Features.Stores.Commands.Create;

public class CreateStoreCommand : IRequest<CustomResponseDto<CreatedStoreResponse>>
{
    public string Name { get; set; }
    public string Photo { get; set; }

    public string[] Roles => new[] { Admin, Write, StoresOperationClaims.Create };

    public class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand, CustomResponseDto<CreatedStoreResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IStoreRepository _storeRepository;
        private readonly StoreBusinessRules _storeBusinessRules;

        public CreateStoreCommandHandler(IMapper mapper, IStoreRepository storeRepository,
                                         StoreBusinessRules storeBusinessRules)
        {
            _mapper = mapper;
            _storeRepository = storeRepository;
            _storeBusinessRules = storeBusinessRules;
        }

        public async Task<CustomResponseDto<CreatedStoreResponse>> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            Store store = _mapper.Map<Store>(request);

            await _storeRepository.AddAsync(store);

            CreatedStoreResponse response = _mapper.Map<CreatedStoreResponse>(store);
            return CustomResponseDto<CreatedStoreResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}