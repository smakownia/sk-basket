using Smakownia.Basket.Application.Services;
using System.Security.Claims;

namespace Smakownia.Basket.Api.Services;

public class IdentityService : IIdentityService
{
    private readonly HttpContext _httpContext;

    public IdentityService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContext = httpContextAccessor.HttpContext ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }

    public Guid? GetIdOrDefault()
    {
        var idString = _httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (idString is null || !Guid.TryParse(idString, out var id))
        {
            return null;
        }

        return id;
    }
}
