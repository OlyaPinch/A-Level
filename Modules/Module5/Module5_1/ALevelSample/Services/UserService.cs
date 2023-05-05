using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ALevelSample.Config;
using ALevelSample.Dtos;
using ALevelSample.Dtos.Requests;
using ALevelSample.Dtos.Responses;
using ALevelSample.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ALevelSample.Services;

public class UserService : IUserService
{
    private readonly IInternalHttpClientService _httpClientService;
    private readonly ILogger<UserService> _logger;
    private readonly ApiOption _options;
    private readonly string _userApi = "api/users/";

    public UserService(
        IInternalHttpClientService httpClientService,
        IOptions<ApiOption> options,
        ILogger<UserService> logger)
    {
        _httpClientService = httpClientService;
        _logger = logger;
        _options = options.Value;
    }

    public async Task<UserDto> GetUserById(int id)
    {
        var result =
            await _httpClientService.SendAsync<BaseResponse<UserDto>, object>(
                $"{_options.Host}{_userApi}{id}",
                HttpMethod.Get);

        if (result?.Data != null)
        {
            _logger.LogInformation($"User with id = {result.Data.Id} was found");
        }

        return result?.Data;
    }

    public async Task<UserResponse> CreateUser(string name, string job)
    {
        var result = await _httpClientService.SendAsync<UserResponseCreate, UserRequest>(
            $"{_options.Host}{_userApi}",
            HttpMethod.Post,
            new UserRequest()
            {
                Job = job,
                Name = name
            });

        if (result != null)
        {
            _logger.LogInformation($"User with id = {result?.Id} was created");
        }

        return result;
    }

    public async Task<List<UserDto>> GetUsers(int page)
    {
        var url = $"{_options.Host}{_userApi}?page={page}";

        var result =
            await _httpClientService.SendAsync<BaseResponse<List<UserDto>>, object>(
                $"{_options.Host}{_userApi}?page={page}", HttpMethod.Get, null);
        if (result != null)
        {
            _logger.LogInformation($"Received users count:{result.Data.Count}");
        }

        return result?.Data ?? new List<UserDto>();
    }

    public async Task<UserResponse> UpdateUserPut(int id, string name, string job)
    {
        var result = await _httpClientService.SendAsync<UserResponseUpdate, UserRequest>(
            $"{_options.Host}{_userApi}{id}",
            HttpMethod.Put,
            new UserRequest()
            {
                Job = job,
                Name = name
            });

        if (result != null)
        {
            _logger.LogInformation($"User with id = {result?.UpdatedAt} was put");
        }

        return result;
    }

    public async Task<UserResponse> UpdateUserPatch(int id, string name, string job)
    {
        var result = await _httpClientService.SendAsync<UserResponseUpdate, UserRequest>(
            $"{_options.Host}{_userApi}{id}",
            HttpMethod.Patch,
            new UserRequest()
            {
                Job = job,
                Name = name
            });

        if (result != null)
        {
            _logger.LogInformation($"User with id = {result?.UpdatedAt} was patch");
        }

        return result;
    }

    public async Task<bool> DeleteUser(int id)
    {
        var result = await _httpClientService.SendAsync(
            $"{_options.Host}{_userApi}{id}",
            HttpMethod.Delete);
        if (result)
        {
            _logger.LogInformation($"User by id {id} was deleted");
        }

        return result;
    }
}