using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ALevelSample.Config;
using ALevelSample.Dtos.Responses;
using ALevelSample.Dtos;
using ALevelSample.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ALevelSample.Dtos.Requests;

namespace ALevelSample.Services
{
    internal class ResourceService : IResourceService
    {
        private readonly IInternalHttpClientService _httpClientService;
        private readonly ILogger<ResourceService> _logger;
        private readonly ApiOption _options;
        private readonly string _resourceApi = "api/unknown/";

        public ResourceService(
            IInternalHttpClientService httpClientService,
            IOptions<ApiOption> options,
            ILogger<ResourceService> logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;
            _options = options.Value;
        }

        public async Task<ResourceDto> GetResourceById(int id)
        {
            var result =
                await _httpClientService.SendAsync<BaseResponse<ResourceDto>, object>(
                    $"{_options.Host}{_resourceApi}{id}",
                    HttpMethod.Get);

            if (result?.Data != null)
            {
                _logger.LogInformation($"Resource with id = {result.Data.Id} was found");
            }
            else
            {
                _logger.LogInformation($"Resource with id = {id} was not found");
            }

            return result?.Data;
        }

        public async Task<List<ResourceDto>> GetResources(int page)
        {
            var result =
                await _httpClientService.SendAsync<BaseListResponse<ResourceDto>, object>(
                    $"{_options.Host}{_resourceApi}?page={page}", HttpMethod.Get, null);
            if (result != null)
            {
                _logger.LogInformation($"Received Resources count:{result.Data.Count}");
            }
            else
            {
                _logger.LogInformation($"Page {page} was NOT found");
            }

            return result?.Data ?? new List<ResourceDto>();
        }
    }
}