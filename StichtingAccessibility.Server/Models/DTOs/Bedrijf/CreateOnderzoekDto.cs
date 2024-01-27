using Microsoft.Identity.Client;

public class CreateOnderzoekDto
{
    public string Titel { get; set; }
    public string Beschrijving { get; set; }
    public bool IsGekeurd { get; set; }
}