using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class TipRepository : EfRepositoryBase<Tip, Guid, BaseDbContext>, ITipRepository
{
    public TipRepository(BaseDbContext context) : base(context)
    {
    }
}