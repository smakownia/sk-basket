using MediatR;
using Microsoft.AspNetCore.Mvc;
using Smakownia.Basket.Application.Commands.AddBasketItem;
using Smakownia.Basket.Application.Commands.RemoveBasketItem;
using Smakownia.Basket.Application.Commands.UpdateBasketItem;
using Smakownia.Basket.Application.Queries.GetBasket;
using Smakownia.Basket.Domain.Models;

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
    public async Task<ActionResult<BasketModel>> Get(CancellationToken token)
    {
        return Ok(await _sender.Send(new GetBasketQuery(), token));
    }

    [HttpPost("items")]
    public async Task<ActionResult<BasketModel>> AddItem([FromBody] AddBasketItemCommand command, CancellationToken token)
    {
        return Ok(await _sender.Send(command, token));
    }

    [HttpPut("items/{id:guid}")]
    public async Task<ActionResult<BasketModel>> UpdateItem([FromBody] UpdateBasketItemCommand command,
                                                            CancellationToken token)
    {
        return Ok(await _sender.Send(command, token));
    }

    [HttpDelete("items/{id:guid}")]
    public async Task<ActionResult<BasketModel>> RemoveItem([FromRoute] Guid id, CancellationToken token)
    {
        return Ok(await _sender.Send(new RemoveBasketItemCommand(id), token));
    }
}
