using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace StichtingAccessibility.Server.Models;

public class Ervaringsdeskundig : Gebruiker
{
    public string? VoorkeurDeelname { get; set; }

    public string? BenaderingOpties { get; set; }

    public string Adres { get; set; } = null!;


    public List<Voogd> Voogden { get; set; } = new();

    public List<BenaderingsOpties> BenaderingsOptiesList { get; set; } = new();

    public List<VoorkeurOnderzoek> VoorkeurOnderzoekList { get; set; } = new();
}

public enum BenaderingsOpties
{
    viaPortaal,
    Telefonisch
}

public enum VoorkeurOnderzoek
{
    interview,
    groepsgesprekken,
    engelstaligonderzoek,
    onlineonderzoek
}