using AutoMapper;
using Smakownia.Basket.Application.Dtos;
using Smakownia.Basket.Domain.Entities;

namespace Smakownia.Basket.Application;

public class BasketMapperProfile : Profile
{
    public BasketMapperProfile()
    {
        CreateMap<BasketEntity, BasketDto>()
            .ForMember(dest => dest.TotalItems,
                       opt => opt.MapFrom(src => src.Items.Aggregate(0, (t, i) => t + i.Quantity)))
            .ForMember(dest => dest.TotalPrice,
                       opt => opt.MapFrom(src => src.Items.Aggregate(0L, (t, i) => t + i.Price * i.Quantity)));

        CreateMap<BasketItem, BasketItemDto>()
            .ForMember(dest => dest.TotalPrice,
                       opt => opt.MapFrom(src => src.Price * src.Quantity));

        CreateMap<long, PriceDto>()
            .ConvertUsing(f => new() { Raw = f, Formatted = decimal.Divide(f, 100).ToString("0.00") + "zł" });
    }
}
