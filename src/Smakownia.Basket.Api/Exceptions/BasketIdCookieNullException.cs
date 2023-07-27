namespace Smakownia.Basket.Api.Exceptions;

public class BasketIdCookieNullException : Exception
{
    public BasketIdCookieNullException() : base("Cookie 'basketId' is required") {}
}
