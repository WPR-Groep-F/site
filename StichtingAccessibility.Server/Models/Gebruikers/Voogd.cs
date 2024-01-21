namespace StichtingAccessibility.Server.Models;

public class Voogd
{
    public int Id { get; set; }
    
    public string Naam { get; set; } = null!;

    public string TelNr { get; set; } = null!;

    public string EmailAdres { get; set; } = null!;
    
    public List<Ervaringsdeskundig> Ervaringsdeskundigen { get; set; }
}