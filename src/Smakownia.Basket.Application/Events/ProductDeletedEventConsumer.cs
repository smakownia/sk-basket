using MassTransit;
using Smakownia.Basket.Domain.Repositories;

namespace Smakownia.Events;

public class ProductDeletedEventConsumer : IConsumer<ProductDeletedEvent>
{
    private readonly IBasketsRepository _basketsRepository;

    public ProductDeletedEventConsumer(IBasketsRepository basketsRepository)
    {
        _basketsRepository = basketsRepository;
    }

    public async Task Consume(ConsumeContext<ProductDeletedEvent> context)
    {
        Console.Write("ergvbstreiogbjtrogbvnjosrtibnjornftgbhoirfdtgbhodnrftbho njdfgobhnodfignhbotgnodpfhbnsduiopfgbhvtdnuiobvndftuiogvbhnio");

        var keys = _basketsRepository.GetKeys();

        foreach (var key in keys)
        {
            var basket = await _basketsRepository.GetAsync(key);

            basket.RemoveItemOrDefault(context.Message.Id);

            await _basketsRepository.SetAsync(basket);
        }
    }
}
