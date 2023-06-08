using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;
using Catalog.Host.Repositories;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Catalog.Host.Data.Abstactions;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Services
{
    public class EntityService<T, TResulDto> : BaseDataService<ApplicationDbContext>, IEntityService<T, TResulDto>
        where T : EntityBase
    {
        private readonly IRepository<T> _repository;
        private readonly IMapper _mapper;

        public EntityService(IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            IRepository<T> repository, IMapper mapper)
            : base(dbContextWrapper, logger)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedItemsResponse<TResulDto>> GetEntitiesAsync(int pageSize, int pageIndex,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _repository.GetByPageAsync(pageIndex, pageSize,
                    include
                );
                return new PaginatedItemsResponse<TResulDto>()
                {
                    Count = result.TotalCount,
                    Data = result.Data.Select(s => _mapper.Map<TResulDto>(s)).ToList(),
                    PageIndex = pageIndex,
                    PageSize = pageSize
                };
            });
        }

        public async Task<TResulDto> GetItemById(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            return _mapper.Map<TResulDto>(result);
        }

        public async Task<PaginatedItemsResponse<TResulDto>> GetItemByExpression(int pageSize, int pageIndex,
            Expression<Func<T, bool>> filter, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _repository.GetByExpressionAsync(pageSize, pageIndex, filter, include);

                return new PaginatedItemsResponse<TResulDto>()
                {
                    Count = result.TotalCount,
                    Data = result.Data.Select(s => _mapper.Map<TResulDto>(s)).ToList(),
                    PageIndex = pageIndex,
                    PageSize = pageSize
                };
            });
        }

        public Task<int?> Add<TRequest>(TRequest entity)
        {
            var entityBase = _mapper.Map<T>(entity);
            return ExecuteSafeAsync(() => _repository.Add(entityBase));
        }

        public Task<int?> Delete(int entityId)
        {
            return ExecuteSafeAsync(() => _repository.Delete(entityId));
        }

        public Task<int?> Update(T entity)
        {
            return ExecuteSafeAsync(() => _repository.Update(entity));
        }
    }
}