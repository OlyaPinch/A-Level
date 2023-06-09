using System.Linq.Expressions;
using AutoMapper;
using Infrastructure.Data;
using Infrastructure.Data.Abstractions;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : EntityBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<Repository<T>> _logger;
        private readonly IMapper _mapper;
        private readonly DbSet<T> _dbSet;

        public Repository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<Repository<T>> logger, IMapper mapper)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
            _mapper = mapper;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var item = await _dbContext.Set<T>().FindAsync(id);

            return item;
        }

        public async Task<PaginatedItems<T>> GetByExpressionAsync(int pageSize, int pageIndex,
            Expression<Func<T, bool>> filter, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            var totalItems = await _dbContext.Set<T>()
                .LongCountAsync(filter);

            var query = _dbContext.Set<T>().AsQueryable().Where(filter);

            if (include != null)
            {
                query = include(query);
            }

            var itemsOnPage = await query
                // .OrderBy(c => c.I)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();


            return new PaginatedItems<T>() { TotalCount = totalItems, Data = itemsOnPage };
        }

        public async Task<PaginatedItems<T>> GetByPageAsync(int pageIndex, int pageSize,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include)
        {
            var totalItems = await _dbContext.Set<T>()
                .LongCountAsync();

            var query = _dbContext.Set<T>().AsQueryable();

            if (include != null)
            {
                query = include(query);
            }

            var itemsOnPage = await query
                // .OrderBy(c => c.I)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();


            return new PaginatedItems<T>() { TotalCount = totalItems, Data = itemsOnPage };
        }

        public async Task<int?> Add(T entity)
        {
            var item = await _dbContext.AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return item.Entity.Id;
        }

        public async Task<int?> Delete(int entityId)
        {
            var en = await _dbContext.Set<T>().FindAsync(entityId);

            if (en != null)
            {
                var item = _dbContext.Set<T>().Remove(en);
                await _dbContext.SaveChangesAsync();
                return item.Entity.Id;
            }

            return 0;
        }

        public async Task<int?> Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<int?> AddOrUpdate(T entity)
        {
            int? result;
            if (entity.Id == 0)
            {
                result = await Add(entity);
            }
            else
            {
                _dbSet.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                result = entity.Id;
            }

            await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}