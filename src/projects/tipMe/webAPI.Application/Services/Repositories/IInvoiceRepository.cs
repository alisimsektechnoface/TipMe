using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IInvoiceRepository : IAsyncRepository<Invoice, Guid>, IRepository<Invoice, Guid>
{
}