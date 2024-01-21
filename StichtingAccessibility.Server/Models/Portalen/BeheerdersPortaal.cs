namespace StichtingAccessibility.Server.Models;

public class BeheerdersPortaal : BedrijfsPortaal
{

    public List<Beheerder> Beheerders { get; set; } = new List<Beheerder>();
}