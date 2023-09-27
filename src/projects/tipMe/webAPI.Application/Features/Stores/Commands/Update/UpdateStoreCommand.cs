using Application.Features.Stores.Constants;
using Application.Features.Stores.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using System.Net;
using Core.Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Stores.Constants.StoresOperationClaims;

namespace Application.Features.Stores.Commands.Update;

public class UpdateStoreCommand : IRequest<CustomResponseDto<UpdatedStoreResponse>>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string[] Roles => new[] { Admin, Write, StoresOperationClaims.Update };

    public class UpdateStoreCommandHandler : IRequestHandler<UpdateStoreCommand, CustomResponseDto<UpdatedStoreResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IStoreRepository _storeRepository;
        private readonly StoreBusinessRules _storeBusinessRules;

        public UpdateStoreCommandHandler(IMapper mapper, IStoreRepository storeRepository,
                                         StoreBusinessRules storeBusinessRules)
        {
            _mapper = mapper;
            _storeRepository = storeRepository;
            _storeBusinessRules = storeBusinessRules;
        }

        public async Task<CustomResponseDto<UpdatedStoreResponse>> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            Store? store = await _storeRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _storeBusinessRules.StoreShouldExistWhenSelected(store);
            store = _mapper.Map(request, store);

            await _storeRepository.UpdateAsync(store!);

            UpdatedStoreResponse response = _mapper.Map<UpdatedStoreResponse>(store);

          return CustomResponseDto<UpdatedStoreResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}