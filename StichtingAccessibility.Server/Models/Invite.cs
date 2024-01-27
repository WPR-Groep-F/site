using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;

namespace StichtingAccessibility.Server.Models;

public class Invite
{
    public int Id { get; set; }
    [NotNull] public Guid Identifier { get; set; }
    [NotNull] public IdentityUser Uitgever { get; set; }
    public IdentityUser? Ontvanger { get; set; }
    [NotNull] public DateTime VerloopDatum { get; set; }
    [NotNull] public DateTime DatumGemaakt { get; set; }

    public string InviteNaam { get; set; }
    public string InviteEmail { get; set; }
    public bool IsGebruikt { get; set; }
    public bool IsVervalt { get; set; }
}