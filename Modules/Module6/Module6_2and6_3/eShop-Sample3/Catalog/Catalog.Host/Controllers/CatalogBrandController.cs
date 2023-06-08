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
public class CatalogBrandController : ControllerBase
{
    private readonly ILogger<CatalogBrandController> _logger;
    private readonly IEntityService<CatalogBrand, CatalogBrandDto> _brandService;
    private readonly IMapper _mapper;

    public CatalogBrandController(ILogger<CatalogBrandController> logger,
        IEntityService<CatalogBrand, CatalogBrandDto> brandService, IMapper mapper
    )
    {
        _logger = logger;
        _brandService = brandService;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddBrand(CreateBrandRequest request)
    {
        var result = await _brandService.Add(request);
        return Ok(new AddItemResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteBrand(int id)
    {
        var result = await _brandService.Delete(id);
        return Ok(new AddItemResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateBrand(CatalogBrand request)
    {
        var result = await _brandService.Update(request);
        return Ok(new AddItemResponse<int?>() { Id = result });
    }
}