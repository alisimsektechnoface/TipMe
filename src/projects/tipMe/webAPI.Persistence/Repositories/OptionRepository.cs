using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class OptionRepository : EfRepositoryBase<Option, Guid, BaseDbContext>, IOptionRepository
{
    public OptionRepository(BaseDbContext context) : base(context)
    {
    }
}