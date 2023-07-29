using Smakownia.Basket.Domain.Exceptions;

namespace Smakownia.Basket.Api.Exceptions;

public class BasketIdInvalidFormatException : BadRequestException
{
    public BasketIdInvalidFormatException() : base("basketId is invalid") { }
}
