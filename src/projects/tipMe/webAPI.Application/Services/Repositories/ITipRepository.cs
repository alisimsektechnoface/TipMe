using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITipRepository : IAsyncRepository<Tip, Guid>, IRepository<Tip, Guid>
{
}