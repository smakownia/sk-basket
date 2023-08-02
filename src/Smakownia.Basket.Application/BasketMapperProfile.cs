using AutoMapper;
using Smakownia.Basket.Application.Dtos;
using Smakownia.Basket.Domain.Entities;

namespace Smakownia.Basket.Application;

public class BasketMapperProfile : Profile
{
    public BasketMapperProfile()
    {
        CreateMap<BasketEntity, BasketDto>();
        CreateMap<BasketItem, BasketItemDto>();
        CreateMap<long, PriceDto>()
            .ConvertUsing(f => new() { Raw = f, Formatted = $"{decimal.Divide(f, 100)}zł" });
    }
}
