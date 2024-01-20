namespace StichtingAccessibility.Server.Models;

public class Vragenlijst : Onderzoek
{
    public List<Vraag> Vragen { get; set; } = new List<Vraag>();
}