namespace StichtingAccessibility.Server.Models;

public class Uitnodiding : Onderzoek
{
    public int Id { get; set; }
    
    public string AdresLocatie { get; set; } = null!;

    public DateOnly Datum { get; set; }

    public TimeOnly Tijd { get; set; }

    public string? RouteBeschrijving { get; set; }
}