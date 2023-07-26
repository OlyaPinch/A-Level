using AutoMapper;
using Infrastructure.Models.Basket;
using Infrastructure.Models.Order;

namespace Order.Host.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        
        CreateMap<BasketData, OrderData>()
            .ForMember(i=>i.OrderItems,op=>op.MapFrom(i=>i.Items));

    }
}