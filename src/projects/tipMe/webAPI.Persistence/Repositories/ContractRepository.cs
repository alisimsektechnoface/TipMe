using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class ContractRepository : EfRepositoryBase<Contract, Guid, BaseDbContext>, IContractRepository
{
    public ContractRepository(BaseDbContext context) : base(context)
    {
    }
}