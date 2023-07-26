using System.Net;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Infrastructure;
using Infrastructure.Data.Entities;
using Infrastructure.Identity;
using Infrastructure.Models;
using Infrastructure.Models.Enums;
using Infrastructure.Models.Requests;
using Infrastructure.Models.Response;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;



namespace Catalog.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBffController : ControllerBase
{
    private readonly ILogger<CatalogBffController> _logger;

    private readonly IEntityService<CatalogItem, CatalogItemDto> _entityService;
    private readonly IEntityService<CatalogBrand, CatalogBrandDto> _brandService;
    private readonly IEntityService<CatalogType, CatalogTypeDto> _typeService;

    public Func<IQueryable<CatalogItem>, IIncludableQueryable<CatalogItem, object>>? ItemsInclude
    {
        get
        {
            return i => i.Include(b => b.CatalogBrand)
                .Include(t => t.CatalogType);
        }
    }

    public CatalogBffController(
        ILogger<CatalogBffController> logger,
        IEntityService<CatalogItem, CatalogItemDto> entityService,
        IEntityService<CatalogBrand, CatalogBrandDto> brandService,
        IEntityService<CatalogType, CatalogTypeDto> typeService)
    {
        _logger = logger;

        _entityService = entityService;
        _brandService = brandService;
        _typeService = typeService;
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Items(PaginatedItemsRequest<CatalogFilter> request)

    {
        var result = await _entityService.GetEntitiesAsync(request.PageSize, request.PageIndex,
            i => (i.CatalogBrandId == request.Filter.BrandId || request.Filter.BrandId == 0) &&
                 (i.CatalogTypeId == request.Filter.TypeId || request.Filter.TypeId == 0),
            ItemsInclude);


        return Ok(result);
    }

    [HttpPost()]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogBrandDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Brands(PaginatedItemsRequest request)
    {
        var result = await _brandService.GetEntitiesAsync(request.PageSize, request.PageIndex);
        return Ok(result);
    }

    [HttpPost()]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogTypeDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Types(PaginatedItemsRequest request)
    {
        var result = await _typeService.GetEntitiesAsync(request.PageSize, request.PageIndex);
        return Ok(result);
    }


    [HttpGet]
    [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Items(int id)
    {
        var result = await _entityService.GetItemById(id);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CatalogBrandDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> BrandById(int id)
    {
        var result = await _brandService.GetItemById(id);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CatalogTypeDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> TypeById(int id)
    {
        var result = await _typeService.GetItemById(id);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByBrand(PaginatedItemsRequest request, int brandId)
    {
        var result =
            await _entityService.GetItemByExpression(request.PageSize, request.PageIndex,
                i => i.CatalogBrandId == brandId, ItemsInclude);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByType(PaginatedItemsRequest request, int typeId)
    {
        var result =
            await _entityService.GetItemByExpression(request.PageSize, request.PageIndex,
                i => i.CatalogTypeId == typeId, ItemsInclude);

        return Ok(result);
    }
}