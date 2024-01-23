using Microsoft.AspNetCore.Identity;

namespace StichtingAccessibility.Server.Models;

public class BedrijfsMedewerker : Gebruiker
{
    public List<Invite> Invites { get; set; } = new List<Invite>();
}