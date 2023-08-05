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
        if (_httpContext.Request.Cookies.TryGetValue("basketId", out var basketIdString)
            && Guid.TryParse(basketIdString, out var basketId))
        {
            return basketId;
        }

        basketId = Guid.NewGuid();

        _httpContext.Response.Cookies.Append("basketId",
                                             basketId.ToString(),
                                             new CookieOptions
                                             {
                                                 Expires = DateTime.Now.AddYears(1),
                                                 HttpOnly = true,
                                             });

        return basketId;
    }
}
