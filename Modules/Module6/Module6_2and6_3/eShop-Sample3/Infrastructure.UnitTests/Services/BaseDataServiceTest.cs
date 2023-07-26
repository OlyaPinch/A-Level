using System.Threading;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Infrastructure.UnitTests.Mocks;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Moq;
using NSubstitute;

namespace Infrastructure.UnitTests.Services;

public class BaseDataServiceTest
{
    private readonly IDbContextTransaction _dbContextTransaction;
    private readonly ILogger<MockService> _logger;
    private readonly MockService _mockService;

    public BaseDataServiceTest()
    {
        var dbContextWrapper = Substitute.For<IDbContextWrapper<MockDbContext>>();

        _dbContextTransaction = Substitute.For<IDbContextTransaction>();

        _logger = Substitute.For<ILogger<MockService>>();

        dbContextWrapper.BeginTransactionAsync(Arg.Any<CancellationToken>()).Returns(_dbContextTransaction);


        _mockService = new MockService(dbContextWrapper, _logger);
    }

    [Fact]
    public async Task ExecuteSafe_Success()
    {
        // arrange

        // act
        await _mockService.RunWithoutException();

        // assert
        _dbContextTransaction.Received(1).CommitAsync(CancellationToken.None);
        _dbContextTransaction.Received(0).RollbackAsync(CancellationToken.None);
    }

    [Fact]
    public async Task ExecuteSafe_Failed()
    {
        // arrange

        // act
        await _mockService.RunWithException();

        // assert
        _dbContextTransaction.Received(0).CommitAsync(CancellationToken.None);
        _dbContextTransaction.Received(1).RollbackAsync(CancellationToken.None);

        _logger.Received(1).Log(
            LogLevel.Error,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((o, t) => o.ToString() !
                .Contains($"transaction is rollbacked")),
            It.IsAny<Exception>(),
            It.IsAny<Func<It.IsAnyType, Exception, string>>() !);
    }
}