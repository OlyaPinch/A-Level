using System.Net;
using AutoMapper;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Infrastructure;
using Infrastructure.Data.Abstractions;
using Infrastructure.Data.Entities;
using Infrastructure.Identity;
using Infrastructure.Models.Response;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
[Route(ComponentDefaults.DefaultRoute)]
public class CRUDController<T, TResultDto, TRequst> : ControllerBase where T : EntityBase
{
    private readonly ILogger<CRUDController<T, TResultDto, TRequst>> _logger;
    readonly IEntityService<T, TResultDto> _baseService;
    private readonly IMapper _mapper;

    public CRUDController(ILogger<CRUDController<T, TResultDto, TRequst>> logger, IMapper mapper,
        IEntityService<T, TResultDto> baseService)
    {
        _logger = logger;
        _mapper = mapper;
        _baseService = baseService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(TRequst request)
    {
        var result = await _baseService.Add(request);
        return Ok(new AddItemResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _baseService.Delete(id);
        return Ok(new AddItemResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(T request)
    {
        var result = await _baseService.Update(request);
        return Ok(new AddItemResponse<int?>() { Id = result });
    }
}