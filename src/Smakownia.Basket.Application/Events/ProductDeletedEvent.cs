namespace Smakownia.Events;

public sealed record ProductDeletedEvent
{
    public ProductDeletedEvent(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private init; }
}
