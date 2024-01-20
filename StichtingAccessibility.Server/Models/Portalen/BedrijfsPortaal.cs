namespace StichtingAccessibility.Server.Models;

public class BedrijfsPortaal
{
    public int Id { get; set; }
    
    public string BedrijfNaam { get; set; } = null!;

    public string BedrijfAdres { get; set; } = null!;

    public string BedrijfInformatie { get; set; } = null!;

    public List<BedrijfsMedewerker> BedrijfsMedewerkers { get; set; } = new List<BedrijfsMedewerker>();

    public List<Onderzoek> Onderzoeken { get; set; } = new List<Onderzoek>();
    
}