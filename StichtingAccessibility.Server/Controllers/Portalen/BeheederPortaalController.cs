using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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


    [HttpGet("InviteBedrijf")]
    public async Task<IActionResult> InviteBedrijf()
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
            VerloopDatum = DateTime.Now.AddDays(7)
        };
        
        beheerder.Invites.Add(invite);


        await _context.SaveChangesAsync();

        return Ok(identifier.ToString());
    }
    
    [HttpPost("InviteBedrijf")]
    public async Task<IActionResult> InviteBedrijf(string email)
    {
        Guid identifier = Guid.NewGuid();
        Invite invite = new Invite();
        
        

        return Ok();
    }
}