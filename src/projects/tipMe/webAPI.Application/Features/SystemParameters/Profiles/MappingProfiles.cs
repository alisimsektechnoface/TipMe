using Application.Features.SystemParameters.Commands.Create;
using Application.Features.SystemParameters.Commands.Delete;
using Application.Features.SystemParameters.Commands.Update;
using Application.Features.SystemParameters.Queries.GetById;
using Application.Features.SystemParameters.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.SystemParameters.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<SystemParameter, CreateSystemParameterCommand>().ReverseMap();
        CreateMap<SystemParameter, CreatedSystemParameterResponse>().ReverseMap();
        CreateMap<SystemParameter, UpdateSystemParameterCommand>().ReverseMap();
        CreateMap<SystemParameter, UpdatedSystemParameterResponse>().ReverseMap();
        CreateMap<SystemParameter, DeleteSystemParameterCommand>().ReverseMap();
        CreateMap<SystemParameter, DeletedSystemParameterResponse>().ReverseMap();
        CreateMap<SystemParameter, GetByIdSystemParameterResponse>().ReverseMap();
        CreateMap<SystemParameter, GetListSystemParameterListItemDto>().ReverseMap();
        CreateMap<IPaginate<SystemParameter>, GetListResponse<GetListSystemParameterListItemDto>>().ReverseMap();
    }
}