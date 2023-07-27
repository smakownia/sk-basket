using Smakownia.Basket.Api.Exceptions;
using Smakownia.Basket.Application.Providers;

namespace Smakownia.Basket.Api.Services;

public class BasketIdentityProvider : IBasketIdentityProvider
{
    private readonly HttpContext _httpContext;

    public BasketIdentityProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContext = httpContextAccessor.HttpContext ?? throw new ArgumentNullException();
    }

    public string GetBasketId()
    {
        _httpContext.Request.Cookies.TryGetValue("basketId", out var basketId);

        if (basketId is null) throw new BasketIdCookieNullException();

        return basketId;
    }
}
