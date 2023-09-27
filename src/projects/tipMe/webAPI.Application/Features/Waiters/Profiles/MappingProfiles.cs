using Application.Features.Waiters.Commands.Create;
using Application.Features.Waiters.Commands.Delete;
using Application.Features.Waiters.Commands.Update;
using Application.Features.Waiters.Queries.GetById;
using Application.Features.Waiters.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Waiters.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Waiter, CreateWaiterCommand>().ReverseMap();
        CreateMap<Waiter, CreatedWaiterResponse>().ReverseMap();
        CreateMap<Waiter, UpdateWaiterCommand>().ReverseMap();
        CreateMap<Waiter, UpdatedWaiterResponse>().ReverseMap();
        CreateMap<Waiter, DeleteWaiterCommand>().ReverseMap();
        CreateMap<Waiter, DeletedWaiterResponse>().ReverseMap();
        CreateMap<Waiter, GetByIdWaiterResponse>().ReverseMap();
        CreateMap<Waiter, GetListWaiterListItemDto>().ReverseMap();
        CreateMap<IPaginate<Waiter>, GetListResponse<GetListWaiterListItemDto>>().ReverseMap();
    }
}