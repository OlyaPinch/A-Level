﻿using System.Linq.Expressions;
using Catalog.Host.Data;
using Catalog.Host.Data.Abstactions;
using Microsoft.EntityFrameworkCore.Query;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<T?> GetByIdAsync(int id);

        Task<PaginatedItems<T>> GetByExpressionAsync(int pageSize, int pageIndex, Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

        Task<PaginatedItems<T>> GetByPageAsync(int pageIndex, int pageSize,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

        Task<int?> Add(T entity);
        Task<int?> Delete(int entityId);
        Task<int?> Update(T entity);
        Task<int?> AddOrUpdate(T entity);
    }
}