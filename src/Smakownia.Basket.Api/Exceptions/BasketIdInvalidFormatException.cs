namespace Smakownia.Basket.Api.Exceptions;

public class BasketIdInvalidFormatException : Exception
{
    public BasketIdInvalidFormatException() : base("basketId is invalid") { }
}
