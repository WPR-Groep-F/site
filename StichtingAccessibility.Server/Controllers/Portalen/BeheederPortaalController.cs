using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StichtingAccessibility.Server.Models;

namespace StichtingAccessibility.Server.Controllers;
[Authorize(Roles = "Beheerder")]
[Route("api/[controller]")]
[ApiController]
public class BeheerderPortaalController : ControllerBase
{
    private readonly StichtingDbContext _context;
    private readonly SignInManager<IdentityUser> _signInManager;
    
    public BeheerderPortaalController(StichtingDbContext context, SignInManager<IdentityUser> signInManager)
    {
        _context = context;
        _signInManager = signInManager;
    }
    [HttpGet("GetBedrijven")]
    public async Task<IActionResult> GetBedrijven()
    {
        // Implementation goes here...

        return Ok();
    }

    [HttpGet("GetOnderzoeken")]
    public async Task<IActionResult> GetOnderzoeken()
    {
        // Implementation goes here...

        return Ok();
    }

    [HttpGet("GetUnApprovedOnderzoeken")]
    public async Task<IActionResult> GetUnApprovedOnderzoeken()
    {
        // Implementation goes here...

        return Ok();
    }

    [HttpPatch("ApproveOnderzoek")]
    public async Task<IActionResult> ApproveOnderzoek()
    {
        // Implementation goes here...

        return Ok();
    }

    [HttpPatch("EditStichtingProfiel")]
    public async Task<IActionResult> EditStichtingProfiel()
    {
        // Implementation goes here...

        return Ok();
    }


    [HttpPost("InviteBedrijf")]
    public async Task<IActionResult> InviteBedrijf([FromBody] InviteDto inviteDto)
    {
        Guid identifier = Guid.NewGuid();
        
        var beheerder = await _signInManager.UserManager.FindByNameAsync(User.Identity.Name) as Beheerder;

        if (beheerder == null)
        {
            return BadRequest("User not found or not a Beheerder");
        }

        Invite invite = new Invite()
        {
            DatumGemaakt = DateTime.Now, 
            Identifier = identifier, 
            Uitgever = beheerder, 
            VerloopDatum = DateTime.Now.AddDays(7),
            InviteEmail = inviteDto.email,
            InviteNaam = inviteDto.naam
        };
        
        beheerder.Invites.Add(invite);


        await _context.SaveChangesAsync();

        return Ok();
    }
    [HttpGet("InviteBedrijf")]
    public async Task<IActionResult> GetAllInviteBedrijf()
    {

    var beheerder = await _signInManager.UserManager.FindByNameAsync(User.Identity.Name) as Beheerder;

    var isInRoll = await _signInManager.UserManager.IsInRoleAsync(beheerder, "Beheerder");
    if (!isInRoll)
    {
        return BadRequest();
    }
    else if(beheerder == null){
        return BadRequest();
    }

var invites = await _context.Invites
    .Include(invite => invite.Uitgever)
    .Where(invite => isInRoll)
    .ToListAsync();

    List<getAllInviteDto> getAllInviteDtos = invites.Select(invite => new getAllInviteDto
{

    Email = invite.InviteEmail,
    Naam = invite.InviteNaam,
    Indetifier = invite.Identifier,
    IsGebruikt = invite.IsGebruikt,
    IsVerval = invite.IsVervalt,
    VerloopDatum = DateOnly.FromDateTime(invite.VerloopDatum),
    DatumGemaakt = DateOnly.FromDateTime(invite.DatumGemaakt), 
    Uitgever = invite.Uitgever.UserName,
    Ontvanger = invite.Ontvanger?.UserName

}).ToList();



    return Ok(getAllInviteDtos);

    }

[HttpPost("NewBedrijfsPortaal")]
public async Task<IActionResult> NewBedrijfsPortaal([FromBody] CreateNewBedrijfportaalDto newBedrijfsPortaal)
{

    BedrijfsPortaal bedrijfsPortaal = new BedrijfsPortaal
    {
        BedrijfNaam = newBedrijfsPortaal.BedrijfNaam,
        BedrijfAdres = newBedrijfsPortaal.BedrijfAdres,
        BedrijfInformatie = newBedrijfsPortaal.BedrijfInformatie
    };
    // Add the new BedrijfsPortaal to the context
    _context.BedrijfsPortaalen.Add(bedrijfsPortaal);

    // Save the changes to the database
    await _context.SaveChangesAsync();

    // Return a success response
    return Ok();
}
}