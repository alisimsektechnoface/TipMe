using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class InvoiceRepository : EfRepositoryBase<Invoice, Guid, BaseDbContext>, IInvoiceRepository
{
    public InvoiceRepository(BaseDbContext context) : base(context)
    {
    }
}