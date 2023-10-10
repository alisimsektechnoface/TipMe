using Core.Domain.Entities;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SystemParameters;

public interface ISystemParametersService
{
    Task<SystemParameter?> GetAsync(
        Expression<Func<SystemParameter, bool>> predicate,
        Func<IQueryable<SystemParameter>, IIncludableQueryable<SystemParameter, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SystemParameter>?> GetListAsync(
        Expression<Func<SystemParameter, bool>>? predicate = null,
        Func<IQueryable<SystemParameter>, IOrderedQueryable<SystemParameter>>? orderBy = null,
        Func<IQueryable<SystemParameter>, IIncludableQueryable<SystemParameter, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SystemParameter> AddAsync(SystemParameter systemParameter);
    Task<SystemParameter> UpdateAsync(SystemParameter systemParameter);
    Task<SystemParameter> DeleteAsync(SystemParameter systemParameter, bool permanent = false);
    Task<SystemParameter> GetByKey(string key);
    Task<string> GetValueByKey(string key);
}
