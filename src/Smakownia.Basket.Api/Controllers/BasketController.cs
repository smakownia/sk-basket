using MediatR;
using Microsoft.AspNetCore.Mvc;
using Smakownia.Basket.Application.Commands.AddBasketItem;
using Smakownia.Basket.Application.Commands.RemoveBasketItem;
using Smakownia.Basket.Application.Commands.UpdateBasketItem;
using Smakownia.Basket.Application.Queries.GetBasket;
using Smakownia.Basket.Domain.Entities;

namespace Smakownia.Basket.Api.Controllers;

[ApiController, Route("api/v1/basket")]
public class BasketController : ControllerBase
{
    private readonly ISender _sender;

    public BasketController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<BasketEntity>> Get(CancellationToken token)
    {
        return Ok(await _sender.Send(new GetBasketQuery(), token));
    }

    [HttpPost("items")]
    public async Task<ActionResult<BasketEntity>> AddItem([FromBody] AddBasketItemCommand command, CancellationToken token)
    {
        return Ok(await _sender.Send(command, token));
    }

    [HttpPut("items/{id:guid}")]
    public async Task<ActionResult<BasketEntity>> UpdateItem([FromBody] UpdateBasketItemCommand command,
                                                            CancellationToken token)
    {
        return Ok(await _sender.Send(command, token));
    }

    [HttpDelete("items/{id:guid}")]
    public async Task<ActionResult<BasketEntity>> RemoveItem([FromRoute] Guid id, CancellationToken token)
    {
        return Ok(await _sender.Send(new RemoveBasketItemCommand(id), token));
    }
}
