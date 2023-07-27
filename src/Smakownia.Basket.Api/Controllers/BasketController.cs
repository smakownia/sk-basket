using Microsoft.AspNetCore.Mvc;
using Smakownia.Basket.Application.Services;
using Smakownia.Basket.Domain.Models;

namespace Smakownia.Basket.Api.Controllers;

[ApiController, Route("api/v1/basket")]
public class BasketController : ControllerBase
{
    private readonly IBasketsService _basketsService;

    public BasketController(IBasketsService basketsService)
    {
        _basketsService = basketsService;
    }

    [HttpGet]
    public async Task<ActionResult<BasketModel>> Get(CancellationToken token)
    {
        return Ok(await _basketsService.GetAsync(token));
    }

    [HttpPost]
    public async Task<ActionResult<BasketModel>> Set(BasketModel basket, CancellationToken token)
    {
        return Ok(await _basketsService.SetAsync(basket, token));
    }
}
