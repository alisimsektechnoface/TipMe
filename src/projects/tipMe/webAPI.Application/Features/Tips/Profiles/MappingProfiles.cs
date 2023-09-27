using Application.Features.Tips.Commands.Create;
using Application.Features.Tips.Commands.Delete;
using Application.Features.Tips.Commands.Update;
using Application.Features.Tips.Queries.GetById;
using Application.Features.Tips.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Tips.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Tip, CreateTipCommand>().ReverseMap();
        CreateMap<Tip, CreatedTipResponse>().ReverseMap();
        CreateMap<Tip, UpdateTipCommand>().ReverseMap();
        CreateMap<Tip, UpdatedTipResponse>().ReverseMap();
        CreateMap<Tip, DeleteTipCommand>().ReverseMap();
        CreateMap<Tip, DeletedTipResponse>().ReverseMap();
        CreateMap<Tip, GetByIdTipResponse>().ReverseMap();
        CreateMap<Tip, GetListTipListItemDto>().ReverseMap();
        CreateMap<IPaginate<Tip>, GetListResponse<GetListTipListItemDto>>().ReverseMap();
    }
}