using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IInvoiceOptionRepository : IAsyncRepository<InvoiceOption, Guid>, IRepository<InvoiceOption, Guid>
{
}