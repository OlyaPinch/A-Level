using AutoMapper;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;

namespace Catalog.Host.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CatalogItem, CatalogItemDto>()
            .ForMember("PictureUrl", opt
                => opt.MapFrom<CatalogItemPictureResolver, string>(c => c.PictureFileName));
        CreateMap<CatalogBrand, CatalogBrandDto>();
        CreateMap<CreateBrandRequest, CatalogBrand>();
        CreateMap<CreateTypeRequest, CatalogType>();
        CreateMap<CreateProductRequest, CatalogItem>();
        CreateMap<CatalogType, CatalogTypeDto>();
    }
}