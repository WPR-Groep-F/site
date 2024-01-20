using Microsoft.AspNetCore.Identity;

namespace StichtingAccessibility.Server.Models;

public class Ervaringsdeskundig : Gebruiker
{
    public string? VoorkeurDeelname { get; set; }

    public string? BenaderingOpties { get; set; }

    public string Adres { get; set; } = null!;

    public List<Voogd> Voogden { get; set; } = new List<Voogd>();

    public List<BenaderingsOpties> BenaderingsOptiesList { get; set; } = new List<BenaderingsOpties>();

    public List<VoorkeurOnderzoek> VoorkeurOnderzoekList { get; set; } = new List<VoorkeurOnderzoek>();



}

public enum BenaderingsOpties {viaPortaal,Telefonisch}
public enum VoorkeurOnderzoek {interview,groepsgesprekken,engelstaligonderzoek,onlineonderzoek}