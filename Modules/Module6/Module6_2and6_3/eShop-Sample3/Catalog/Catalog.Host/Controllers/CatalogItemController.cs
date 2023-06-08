using System.Net;
using AutoMapper;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogItemController : ControllerBase
{
    private readonly ILogger<CatalogItemController> _logger;
    private readonly IEntityService<CatalogItem, CatalogItemDto> _catalogItemService;
    private readonly IMapper _mapper;

    public CatalogItemController(
        ILogger<CatalogItemController> logger,
        IEntityService<CatalogItem, CatalogItemDto> catalogItemService, IMapper mapper)
    {
        _logger = logger;
        _catalogItemService = catalogItemService;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(CreateProductRequest request)
    {
        var result = await _catalogItemService.Add(request);
        return Ok(new AddItemResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _catalogItemService.Delete(id);
        return Ok(new AddItemResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(CatalogItem request)
    {
        var result = await _catalogItemService.Update(request);
        return Ok(new AddItemResponse<int?>() { Id = result });
    }
}