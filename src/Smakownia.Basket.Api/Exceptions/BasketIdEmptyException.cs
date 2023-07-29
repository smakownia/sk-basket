using Smakownia.Basket.Domain.Exceptions;

namespace Smakownia.Basket.Api.Exceptions;

public class BasketIdEmptyException : BadRequestException
{
    public BasketIdEmptyException() : base("basketId is empty") { }
}
