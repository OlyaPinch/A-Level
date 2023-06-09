using System.Linq.Expressions;
using AutoMapper;
using Infrastructure.Data;
using Infrastructure.Data.Abstractions;
using Infrastructure.Models.Response;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Infrastructure.UnitTests
{

    public class EntityServiceTests
    {
        [Fact]
        public async Task GetEntitiesAsync_ShouldReturnPaginatedItemsResponse()
        {
            // Arrange
            var dbContextWrapper = Substitute.For<IDbContextWrapper<ApplicationDbContext>>();
            var logger = Substitute.For<ILogger<BaseDataService<ApplicationDbContext>>>();
            var repository = Substitute.For<IRepository<EntityBase>>();
            var mapper = Substitute.For<IMapper>();

            var service = new EntityService<EntityBase, ResultDto>(dbContextWrapper, logger, repository, mapper);

            var pageSize = 10;
            var pageIndex = 1;
            var include = Substitute.For<Func<IQueryable<EntityBase>, IIncludableQueryable<EntityBase, object>>>();
            var expectedResult = new PaginatedItemsResponse<ResultDto>
            {
                Count = 20,
                Data = new List<ResultDto> { new ResultDto(), new ResultDto() },
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            repository.GetByPageAsync(pageIndex, pageSize, include)
                .Returns(new PaginatedItems<EntityBase> { TotalCount = 20, Data = new List<EntityBase> { new EntityBase(), new EntityBase() } });

            mapper.Map<ResultDto>(Arg.Any<EntityBase>())
                .Returns(new ResultDto());

            // Act
            var result = await service.GetEntitiesAsync(pageSize, pageIndex, include);

            // Assert
            Assert.Equal(expectedResult.Count, result.Count);
            Assert.Equal(expectedResult.Data.Count(), result.Data.Count());
            Assert.Equal(expectedResult.PageIndex, result.PageIndex);
            Assert.Equal(expectedResult.PageSize, result.PageSize);
        }

        [Fact]
        public async Task GetItemById_ShouldReturnDto()
        {
            // Arrange
            var dbContextWrapper = Substitute.For<IDbContextWrapper<ApplicationDbContext>>();
            var logger = Substitute.For<ILogger<BaseDataService<ApplicationDbContext>>>();
            var repository = Substitute.For<IRepository<EntityBase>>();
            var mapper = Substitute.For<IMapper>();

            var service = new EntityService<EntityBase, ResultDto>(dbContextWrapper, logger, repository, mapper);

            var id = 1;
            var entity = new EntityBase();
            var expectedResult = new ResultDto();

            repository.GetByIdAsync(id)
                .Returns(entity);

            mapper.Map<ResultDto>(entity)
                .Returns(expectedResult);

            // Act
            var result = await service.GetItemById(id);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task GetItemByExpression_ShouldReturnPaginatedItemsResponse()
        {
            // Arrange
            var dbContextWrapper = Substitute.For<IDbContextWrapper<ApplicationDbContext>>();
            var logger = Substitute.For<ILogger<BaseDataService<ApplicationDbContext>>>();
            var repository = Substitute.For<IRepository<EntityBase>>();
            var mapper = Substitute.For<IMapper>();

            var service = new EntityService<EntityBase, ResultDto>(dbContextWrapper, logger, repository, mapper);

            var pageSize = 10;
            var pageIndex = 1;
            Expression<Func<EntityBase, bool>> filter = i=>true;
            var include = Substitute.For<Func<IQueryable<EntityBase>, IIncludableQueryable<EntityBase, object>>>();
            var expectedResult = new PaginatedItemsResponse<ResultDto>
            {
                Count = 20,
                Data = new List<ResultDto> { new ResultDto(), new ResultDto() },
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            repository.GetByExpressionAsync(pageSize, pageIndex, filter, include)
                .Returns(new PaginatedItems<EntityBase> { TotalCount = 20, Data = new List<EntityBase> { new EntityBase(), new EntityBase() } });

            mapper.Map<ResultDto>(Arg.Any<EntityBase>())
                .Returns(new ResultDto());

            // Act
            var result = await service.GetItemByExpression(pageSize, pageIndex, filter, include);

            // Assert
            Assert.Equal(expectedResult.Count, result.Count);
            Assert.Equal(expectedResult.Data.Count(), result.Data.Count());
            Assert.Equal(expectedResult.PageIndex, result.PageIndex);
            Assert.Equal(expectedResult.PageSize, result.PageSize);
        }

        [Fact]
        public async Task Add_ShouldReturnEntityId()
        {
            // Arrange
            var dbContextWrapper = Substitute.For<IDbContextWrapper<ApplicationDbContext>>();
            var logger = Substitute.For<ILogger<BaseDataService<ApplicationDbContext>>>();
            var repository = Substitute.For<IRepository<EntityBase>>();
            var mapper = Substitute.For<IMapper>();

            var service = new EntityService<EntityBase, ResultDto>(dbContextWrapper, logger, repository, mapper);

            var entityRequest = new EntityRequest();
            var entityBase = new EntityBase();
            var expectedEntityId = 1;

            mapper.Map<EntityBase>(entityRequest)
                .Returns(entityBase);

            repository.Add(entityBase)
                .Returns(expectedEntityId);

            // Act
            var result = await service.Add(entityRequest);

            // Assert
            Assert.Equal(expectedEntityId, result);
        }

        [Fact]
        public async Task Delete_ShouldReturnEntityId()
        {
            // Arrange
            var dbContextWrapper = Substitute.For<IDbContextWrapper<ApplicationDbContext>>();
            var logger = Substitute.For<ILogger<BaseDataService<ApplicationDbContext>>>();
            var repository = Substitute.For<IRepository<EntityBase>>();
            var mapper = Substitute.For<IMapper>();

            var service = new EntityService<EntityBase, ResultDto>(dbContextWrapper, logger, repository, mapper);

            var entityId = 1;
            var expectedEntityId = 1;

            repository.Delete(entityId)
                .Returns(expectedEntityId);

            // Act
            var result = await service.Delete(entityId);

            // Assert
            Assert.Equal(expectedEntityId, result);
        }

        [Fact]
        public async Task Update_ShouldReturnEntityId()
        {
            // Arrange
            var dbContextWrapper = Substitute.For<IDbContextWrapper<ApplicationDbContext>>();
            var logger = Substitute.For<ILogger<BaseDataService<ApplicationDbContext>>>();
            var repository = Substitute.For<IRepository<EntityBase>>();
            var mapper = Substitute.For<IMapper>();

            var service = new EntityService<EntityBase, ResultDto>(dbContextWrapper, logger, repository, mapper);

            var entity = new EntityBase();
            var expectedEntityId = 1;

            repository.Update(entity)
                .Returns(expectedEntityId);

            // Act
            var result = await service.Update(entity);

            // Assert
            Assert.Equal(expectedEntityId, result);
        }
    }

    public class EntityRequest
    {
    }

    public class ResultDto
    {
    }
}
