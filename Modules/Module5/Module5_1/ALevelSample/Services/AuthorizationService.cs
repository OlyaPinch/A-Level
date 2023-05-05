using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ALevelSample.Config;
using ALevelSample.Dtos.Requests;
using ALevelSample.Dtos.Responses;
using ALevelSample.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ALevelSample.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly IInternalHttpClientService _httpClientService;
    private readonly ILogger<AuthorizationService> _logger;
    private readonly ApiOption _options;
    private readonly string _authorApi = "api/register";
    private readonly string _loginApi = "api/login";

    public AuthorizationService(
        IInternalHttpClientService httpClientService,
        IOptions<ApiOption> options,
        ILogger<AuthorizationService> logger)
    {
        _httpClientService = httpClientService;
        _logger = logger;
        _options = options.Value;
    }

    public async Task<RegisterResponse> Registration(string email, string password = null)
    {
        var result = await _httpClientService.SendAsync<RegisterResponse, AuthorizationRequest>(
            $"{_options.Host}{_authorApi}",
            HttpMethod.Post,
            new AuthorizationRequest()
            {
                Email = email,
                Password = password
            });

        if (result.IsSuccess)
        {
            _logger.LogInformation($"User with id = {result?.Id} is registered");
        }
        else
        {
            _logger.LogInformation($"error : {result?.Error}");
        }

        return result;
    }

    public async Task<LoginResponse> Login(string email, string password = null)
    {
        var result = await _httpClientService.SendAsync<LoginResponse, AuthorizationRequest>(
            $"{_options.Host}{_loginApi}",
            HttpMethod.Post,
            new AuthorizationRequest()
            {
                Email = email,
                Password = password
            });

        if (result.IsSuccess)
        {
            _logger.LogInformation($"Login  is successful");
        }
        else
        {
            _logger.LogInformation($"error : {result.Error} ");
        }

        return result;
    }
}