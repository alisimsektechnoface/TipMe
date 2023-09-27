using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class StoreRepository : EfRepositoryBase<Store, Guid, BaseDbContext>, IStoreRepository
{
    public StoreRepository(BaseDbContext context) : base(context)
    {
    }
}