namespace Cars.Models;

public record Car
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string Name { get; init; }
    public required string Description { get; init; }
    public DateTimeOffset CreatedTime { get; init; } = DateTimeOffset.UtcNow;

    public CarDto ToDto() => new(Id, Name, Description, CreatedTime);
}