using System.Diagnostics.CodeAnalysis;

namespace StichtingAccessibility.Server.Models;

public class Vraag
{
    public int Id { get; set; }

    public string Titel { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string? Beschrijving { get; set; }

    [NotNull] public string Antwoord { get; set; }
}