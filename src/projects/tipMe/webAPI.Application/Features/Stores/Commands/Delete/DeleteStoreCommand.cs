using Application.Features.Stores.Constants;
using Application.Features.Stores.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities;
using MediatR;
using System.Net;
using static Application.Features.Stores.Constants.StoresOperationClaims;

namespace Application.Features.Stores.Commands.Delete;

public class DeleteStoreCommand : IRequest<CustomResponseDto<DeletedStoreResponse>>
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, StoresOperationClaims.Delete };

    public class DeleteStoreCommandHandler : IRequestHandler<DeleteStoreCommand, CustomResponseDto<DeletedStoreResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IStoreRepository _storeRepository;
        private readonly StoreBusinessRules _storeBusinessRules;

        public DeleteStoreCommandHandler(IMapper mapper, IStoreRepository storeRepository,
                                         StoreBusinessRules storeBusinessRules)
        {
            _mapper = mapper;
            _storeRepository = storeRepository;
            _storeBusinessRules = storeBusinessRules;
        }

        public async Task<CustomResponseDto<DeletedStoreResponse>> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {
            Store? store = await _storeRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _storeBusinessRules.StoreShouldExistWhenSelected(store);

            await _storeRepository.DeleteAsync(store!);

            DeletedStoreResponse response = _mapper.Map<DeletedStoreResponse>(store);

            return CustomResponseDto<DeletedStoreResponse>.Success((int)HttpStatusCode.OK, response, true);

        }
    }
}