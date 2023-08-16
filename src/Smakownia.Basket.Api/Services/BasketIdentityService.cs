using Smakownia.Basket.Application.Services;

namespace Smakownia.Basket.Api.Services;

public class BasketIdentityService : IBasketIdentityService
{
    private const string IdCookieName = "basketId";
    private readonly HttpContext _httpContext;
    private readonly IIdentityService _identityService;

    public BasketIdentityService(IHttpContextAccessor httpContextAccessor, IIdentityService identityService)
    {
        _httpContext = httpContextAccessor.HttpContext ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _identityService = identityService;
    }

    public Guid GetId()
    {
        var identityId = _identityService.GetIdOrDefault();
        Console.WriteLine($"///////////////////////// {identityId}");
        if (identityId is not null)
        {
            return identityId.Value;
        }

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
