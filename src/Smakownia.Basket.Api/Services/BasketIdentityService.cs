using Smakownia.Basket.Api.Exceptions;
using Smakownia.Basket.Application.Services;

namespace Smakownia.Basket.Api.Services;

public class BasketIdentityService : IBasketIdentityService
{
    private readonly HttpContext _httpContext;

    public BasketIdentityService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContext = httpContextAccessor.HttpContext ?? throw new ArgumentNullException();
    }

    public Guid GetId()
    {
        _httpContext.Request.Cookies.TryGetValue("basketId", out var basketIdString);

        if (string.IsNullOrEmpty(basketIdString))
        {
            throw new BasketIdEmptyException();
        }

        if(!Guid.TryParse(basketIdString, out var basketId))
        {
            throw new BasketIdInvalidFormatException();
        }

        return basketId;
    }
}
