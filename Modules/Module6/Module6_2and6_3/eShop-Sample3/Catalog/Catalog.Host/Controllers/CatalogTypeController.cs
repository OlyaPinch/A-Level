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
public class CatalogTypeController : ControllerBase
{
    private readonly ILogger<CatalogTypeController> _logger;
    private readonly IEntityService<CatalogType, CatalogTypeDto> _typeService;
    private readonly IMapper _mapper;

    public CatalogTypeController(ILogger<CatalogTypeController> logger, IMapper mapper,
        IEntityService<CatalogType, CatalogTypeDto> typeService)
    {
        _logger = logger;
        _mapper = mapper;
        _typeService = typeService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(CreateTypeRequest request)
    {
        var result = await _typeService.Add(request);
        return Ok(new AddItemResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _typeService.Delete(id);
        return Ok(new AddItemResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(CatalogType request)
    {
        var result = await _typeService.Update(request);
        return Ok(new AddItemResponse<int?>() { Id = result });
    }
}