using Application.Features.Stores.Commands.Create;
using Application.Features.Stores.Commands.Delete;
using Application.Features.Stores.Commands.Update;
using Application.Features.Stores.Queries.GetById;
using Application.Features.Stores.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Stores.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Store, CreateStoreCommand>().ReverseMap();
        CreateMap<Store, CreatedStoreResponse>().ReverseMap();
        CreateMap<Store, UpdateStoreCommand>().ReverseMap();
        CreateMap<Store, UpdatedStoreResponse>().ReverseMap();
        CreateMap<Store, DeleteStoreCommand>().ReverseMap();
        CreateMap<Store, DeletedStoreResponse>().ReverseMap();
        CreateMap<Store, GetByIdStoreResponse>().ReverseMap();
        CreateMap<Store, GetListStoreListItemDto>().ReverseMap();
        CreateMap<IPaginate<Store>, GetListResponse<GetListStoreListItemDto>>().ReverseMap();
    }
}