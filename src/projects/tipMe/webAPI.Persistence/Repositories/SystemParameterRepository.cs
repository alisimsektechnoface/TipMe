using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace Persistence.Repositories;

public class SystemParameterRepository : EfRepositoryBase<SystemParameter, Guid, BaseDbContext>, ISystemParameterRepository
{
    public SystemParameterRepository(BaseDbContext context) : base(context)
    {
    }
}