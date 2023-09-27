using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IOptionRepository : IAsyncRepository<Option, Guid>, IRepository<Option, Guid>
{
}