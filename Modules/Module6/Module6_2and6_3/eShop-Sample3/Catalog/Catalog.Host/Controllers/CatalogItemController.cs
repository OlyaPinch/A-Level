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
public class CatalogItemController : CRUDController<CatalogItem, CatalogItemDto, CreateProductRequest>
{
    public CatalogItemController(ILogger<CRUDController<CatalogItem, CatalogItemDto, CreateProductRequest>> logger,
        IMapper mapper, IEntityService<CatalogItem, CatalogItemDto> baseService) : base(logger, mapper, baseService)
    {
    }
}