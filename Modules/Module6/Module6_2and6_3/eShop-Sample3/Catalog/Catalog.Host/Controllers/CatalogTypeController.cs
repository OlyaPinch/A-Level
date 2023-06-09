using System.Net;
using AutoMapper;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Infrastructure;
using Infrastructure.Data.Entities;
using Infrastructure.Models.Response;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogTypeController : CRUDController<CatalogType, CatalogTypeDto, CreateTypeRequest>
{
    public CatalogTypeController(ILogger<CRUDController<CatalogType, CatalogTypeDto, CreateTypeRequest>> logger,
        IMapper mapper, IEntityService<CatalogType, CatalogTypeDto> baseService) : base(logger, mapper, baseService)
    {
    }
}