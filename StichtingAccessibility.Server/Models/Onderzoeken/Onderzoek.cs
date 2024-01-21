using System.Diagnostics.CodeAnalysis;

namespace StichtingAccessibility.Server.Models;

public class Onderzoek
{
    public int Id { get; set; }

    public string Titel { get; set; } = null!;

    public string Beschrijving { get; set; } = null!;

    public DateOnly DatumGeplaatst { get; set; }

    public bool IsGekeurd { get; set; }

    [NotNull] public BedrijfsPortaal Bedrijf { get; set; }

    public List<Ervaringsdeskundig> Ervaringsdeskundigen { get; set; } = new();
}