using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class InvoiceOptionRepository : EfRepositoryBase<InvoiceOption, Guid, BaseDbContext>, IInvoiceOptionRepository
{
    public InvoiceOptionRepository(BaseDbContext context) : base(context)
    {
    }
}