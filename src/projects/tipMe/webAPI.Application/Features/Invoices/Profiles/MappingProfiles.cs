using Application.Features.Invoices.Commands.Create;
using Application.Features.Invoices.Commands.Delete;
using Application.Features.Invoices.Commands.Update;
using Application.Features.Invoices.Queries.GetById;
using Application.Features.Invoices.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Invoices.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Invoice, CreateInvoiceCommand>().ReverseMap();
        CreateMap<Invoice, CreatedInvoiceResponse>().ReverseMap();
        CreateMap<Invoice, UpdateInvoiceCommand>().ReverseMap();
        CreateMap<Invoice, UpdatedInvoiceResponse>().ReverseMap();
        CreateMap<Invoice, DeleteInvoiceCommand>().ReverseMap();
        CreateMap<Invoice, DeletedInvoiceResponse>().ReverseMap();
        CreateMap<Invoice, GetByIdInvoiceResponse>().ReverseMap();
        CreateMap<Invoice, GetListInvoiceListItemDto>().ReverseMap();
        CreateMap<IPaginate<Invoice>, GetListResponse<GetListInvoiceListItemDto>>().ReverseMap();
    }
}