using Smakownia.Basket.Application.Services;

namespace Smakownia.Basket.Api.Services;

public class BasketIdentityService : IBasketIdentityService
{
    private const string IdCookieName = "basketId";
    private readonly HttpContext _httpContext;

    public BasketIdentityService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContext = httpContextAccessor.HttpContext ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }

    public Guid GetId()
    {
        if (_httpContext.Request.Cookies.TryGetValue(IdCookieName, out var basketIdString)
            && Guid.TryParse(basketIdString, out var basketId))
        {
            return basketId;
        }

        basketId = Guid.NewGuid();

        var cookieOptions = new CookieOptions
        {
            Expires = DateTime.Now.AddYears(1),
            HttpOnly = true,
        };

        _httpContext.Response.Cookies.Append(IdCookieName, basketId.ToString(), cookieOptions);

        return basketId;
    }
}
