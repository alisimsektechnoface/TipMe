using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISystemParameterRepository : IAsyncRepository<SystemParameter, Guid>, IRepository<SystemParameter, Guid>
{
}