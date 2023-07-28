namespace Smakownia.Basket.Api.Exceptions;

public class BasketIdEmptyException : Exception
{
    public BasketIdEmptyException() : base("basketId is empty") { }
}
