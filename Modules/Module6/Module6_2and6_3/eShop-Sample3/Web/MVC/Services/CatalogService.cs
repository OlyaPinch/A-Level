using System.Diagnostics;
using Catalog.Host.Models.Dtos;
using Infrastructure.Models;
using Infrastructure.Models.Requests;
using Infrastructure.Models.Response;

using MVC.Models.Enums;
using MVC.Services.Interfaces;
using MVC.ViewModels;


namespace MVC.Services;

public class CatalogService : ICatalogService
{
    private readonly IOptions<AppSettings> _settings;
    private readonly IHttpClientService _httpClient;
    private readonly ILogger<CatalogService> _logger;

    public CatalogService(IHttpClientService httpClient, ILogger<CatalogService> logger, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings;
        _logger = logger;
    }

    public async Task<ViewModels.Catalog> GetCatalogItems(int page, int take, int brand = 0, int type = 0)
    {
        CatalogFilter filter = new CatalogFilter();
        filter.BrandId = brand;
        filter.TypeId = type;


        var result = await _httpClient.SendAsync<ViewModels.Catalog>(
            $"{_settings.Value.CatalogUrl}/items",
            HttpMethod.Post,
            new PaginatedItemsRequest<CatalogFilter>()
            {
                PageIndex = page,
                PageSize = take,
                Filter = filter
            });

        return result;
    }

    public async Task<IEnumerable<SelectListItem>> GetBrands(int page = 0, int pagezSize = Int32.MaxValue)
    {
        var result =
            await _httpClient.SendAsync<PaginatedItemsResponse<CatalogBrand>>(
                $"{_settings.Value.CatalogUrl}/Brands", HttpMethod.Post,
                new PaginatedItemsRequest()
                {
                    PageIndex = page,
                    PageSize = pagezSize
                });

        //Debug.Assert(result != null, nameof(result) + " != null");
        return result?.Data?.Select(
            i => new SelectListItem(i.Brand, i.Id.ToString()));
    }

    public async Task<IEnumerable<SelectListItem>> GetTypes(int page = 0, int pagezSize = Int32.MaxValue)
    {
        var result =
            await _httpClient.SendAsync<PaginatedItemsResponse<CatalogType>>(
                $"{_settings.Value.CatalogUrl}/Types", HttpMethod.Post,
                new PaginatedItemsRequest()
                {
                    PageIndex = page,
                    PageSize = pagezSize
                });


        Debug.Assert(result != null, nameof(result) + " != null");

        return result?.Data?.Select(i => new SelectListItem(i.Type, i.Id.ToString())) ?? new List<SelectListItem>();
    }

 public async Task<CatalogItem> GetItemById(int id)
 {

     var result = await _httpClient.SendAsync<CatalogItem>(
         $"{_settings.Value.CatalogUrl}/Items?id={id}",
         HttpMethod.Get);
         
     return result;
 }
}