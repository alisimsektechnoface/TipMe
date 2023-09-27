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

namespace Application.Features.Stores.Queries.GetById;

public class GetByIdStoreQuery : IRequest<CustomResponseDto<GetByIdStoreResponse>>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdStoreQueryHandler : IRequestHandler<GetByIdStoreQuery, CustomResponseDto<GetByIdStoreResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IStoreRepository _storeRepository;
        private readonly StoreBusinessRules _storeBusinessRules;

        public GetByIdStoreQueryHandler(IMapper mapper, IStoreRepository storeRepository, StoreBusinessRules storeBusinessRules)
        {
            _mapper = mapper;
            _storeRepository = storeRepository;
            _storeBusinessRules = storeBusinessRules;
        }

        public async Task<CustomResponseDto<GetByIdStoreResponse>> Handle(GetByIdStoreQuery request, CancellationToken cancellationToken)
        {
            Store? store = await _storeRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _storeBusinessRules.StoreShouldExistWhenSelected(store);

            GetByIdStoreResponse response = _mapper.Map<GetByIdStoreResponse>(store);

          return CustomResponseDto<GetByIdStoreResponse>.Success((int)HttpStatusCode.OK, response, true);
        }
    }
}