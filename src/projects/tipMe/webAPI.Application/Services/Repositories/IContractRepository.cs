using Core.Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IContractRepository : IAsyncRepository<Contract, Guid>, IRepository<Contract, Guid>
{
}