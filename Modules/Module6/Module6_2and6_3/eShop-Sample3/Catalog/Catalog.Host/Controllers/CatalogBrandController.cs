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
public class CatalogBrandController : CRUDController<CatalogBrand, CatalogBrandDto, CreateBrandRequest>
{
    public CatalogBrandController(ILogger<CRUDController<CatalogBrand, CatalogBrandDto, CreateBrandRequest>> logger,
        IMapper mapper, IEntityService<CatalogBrand, CatalogBrandDto> baseService) : base(logger, mapper, baseService)
    {
    }
}