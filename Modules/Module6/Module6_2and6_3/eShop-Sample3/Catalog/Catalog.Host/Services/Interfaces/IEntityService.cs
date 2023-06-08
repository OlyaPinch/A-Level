﻿using Catalog.Host.Models.Response;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Catalog.Host.Data.Abstactions;

namespace Catalog.Host.Services.Interfaces
{
    public interface IEntityService<T, TResulDto> where T : EntityBase
    {
        Task<PaginatedItemsResponse<TResulDto>> GetEntitiesAsync(int pageSize, int pageIndex,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

        Task<TResulDto> GetItemById(int id);

        Task<PaginatedItemsResponse<TResulDto>> GetItemByExpression(int pageSize, int pageIndex,
            Expression<Func<T, bool>> filter, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

        Task<int?> Add<TRequest>(TRequest entity);
        Task<int?> Delete(int entityId);
        Task<int?> Update(T entity);
    }
}