using Microsoft.AspNetCore.Mvc;
using StichtingAccessibility.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace StichtingAccessibility.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BedrijfPortaalController : ControllerBase
{
    private readonly StichtingDbContext _context;
    private readonly SignInManager<IdentityUser> _signInManager;

    public BedrijfPortaalController(StichtingDbContext context, SignInManager<IdentityUser> signInManager)
    {
        _context = context;
        _signInManager = signInManager;
    }

    [HttpGet("GetOnderzoeken")]
    public async Task<IActionResult> GetOnderzoeken()
    {
        // Implementation goes here...

        return Ok();
    }

    [HttpPost("CreateOnderzoek")]
    public async Task<IActionResult> CreateOnderzoek([FromBody] CreateOnderzoekDto onderzoekDto)
    {
        var bedrijf = await _context.BedrijfsPortaalen.FindAsync(1);

        var onderzoek = new Onderzoek()
        {
            Titel = onderzoekDto.Titel,
            Beschrijving = onderzoekDto.Beschrijving,
            DatumGeplaatst = DateOnly.FromDateTime(DateTime.Today),
            IsGekeurd = onderzoekDto.IsGekeurd,
            Bedrijf = bedrijf
        };

        await _context.Onderzoeken.AddAsync(onderzoek);

        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpPatch("EditOnderzoek")]
    public async Task<IActionResult> EditOnderzoek()
    {
        return Ok();
    }

    [HttpPost("InviteMedewerker")]
    public async Task<IActionResult> InviteMedewerker()
    {
        return Ok();
    }

    [HttpPatch("EditBedrijfProfiel")]
    public async Task<IActionResult> EditBedrijfProfiel()
    {
        return Ok();
    }
}