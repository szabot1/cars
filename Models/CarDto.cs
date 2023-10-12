using System.ComponentModel.DataAnnotations;

namespace Cars.Models;

public record CarDto(Guid Id, string Name, string Description, DateTimeOffset RegistrationTime);

public record CreateCarDto
{
    [Required]
    public string Name { get; init; } = null!;

    [Required]
    public string Description { get; init; } = null!;
}