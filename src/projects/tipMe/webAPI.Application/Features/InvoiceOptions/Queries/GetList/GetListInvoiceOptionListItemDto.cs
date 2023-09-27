using Core.Application.Dtos;

namespace Application.Features.InvoiceOptions.Queries.GetList;

public class GetListInvoiceOptionListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid InvoiceId { get; set; }
    public Guid OptionId { get; set; }
}