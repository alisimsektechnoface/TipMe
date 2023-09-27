using Application.Features.InvoiceOptions.Commands.Create;
using Application.Features.InvoiceOptions.Commands.Delete;
using Application.Features.InvoiceOptions.Commands.Update;
using Application.Features.InvoiceOptions.Queries.GetById;
using Application.Features.InvoiceOptions.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.InvoiceOptions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<InvoiceOption, CreateInvoiceOptionCommand>().ReverseMap();
        CreateMap<InvoiceOption, CreatedInvoiceOptionResponse>().ReverseMap();
        CreateMap<InvoiceOption, UpdateInvoiceOptionCommand>().ReverseMap();
        CreateMap<InvoiceOption, UpdatedInvoiceOptionResponse>().ReverseMap();
        CreateMap<InvoiceOption, DeleteInvoiceOptionCommand>().ReverseMap();
        CreateMap<InvoiceOption, DeletedInvoiceOptionResponse>().ReverseMap();
        CreateMap<InvoiceOption, GetByIdInvoiceOptionResponse>().ReverseMap();
        CreateMap<InvoiceOption, GetListInvoiceOptionListItemDto>().ReverseMap();
        CreateMap<IPaginate<InvoiceOption>, GetListResponse<GetListInvoiceOptionListItemDto>>().ReverseMap();
    }
}