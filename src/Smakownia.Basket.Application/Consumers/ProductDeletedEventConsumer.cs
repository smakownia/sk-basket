using MassTransit;
using Smakownia.Basket.Domain.Repositories;
using Smakownia.Events;

namespace Smakownia.Basket.Application.Consumers;

public class ProductDeletedEventConsumer : IConsumer<ProductDeleted>
{
    private readonly IBasketsRepository _basketsRepository;

    public ProductDeletedEventConsumer(IBasketsRepository basketsRepository)
    {
        _basketsRepository = basketsRepository;
    }

    public async Task Consume(ConsumeContext<ProductDeleted> context)
    {
        var keys = _basketsRepository.GetKeys();

        foreach (var key in keys)
        {
            var basket = await _basketsRepository.GetAsync(key);

            basket.RemoveItemOrDefault(context.Message.Id);

            await _basketsRepository.SetAsync(basket);
        }
    }
}
