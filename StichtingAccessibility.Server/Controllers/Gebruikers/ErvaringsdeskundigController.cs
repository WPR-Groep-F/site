using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StichtingAccessibility.Server.Models;

namespace StichtingAccessibility.Server.Controllers;

[Authorize(Roles = "Ervaringsdeskundig")]
[Route("api/[controller]")]
[ApiController]
public class ErvaringsdeskundigController : ControllerBase
{
    private readonly StichtingDbContext _context;
    private readonly SignInManager<IdentityUser> _signInManager;

    public ErvaringsdeskundigController(StichtingDbContext context, SignInManager<IdentityUser> signInManager)
    {
        _context = context;
        _signInManager = signInManager;
    }

    [HttpGet("Profiel")]
    public async Task<ActionResult<Ervaringsdeskundig>> GetProfiel()
    {
        var user = await _signInManager.UserManager.FindByNameAsync(User.Identity.Name);

        if (user == null) return Unauthorized("User is not authenticated");

        var ervaringsdeskundige = await _context.Ervaringsdeskundigen.FindAsync(user.Id);

        if (ervaringsdeskundige == null)
        {
            Console.WriteLine("Ervaringsdeskundige niet gevonden");
            return NotFound("Ervaringsdeskundige niet gevonden");
        }

        return ervaringsdeskundige;
    }

    [HttpPatch("Profiel")]
    public IActionResult UpdateProfile()
    {
        return Ok();
    }

    [HttpGet("Onderzoeken")]
    public IActionResult GetOnderzoeken()
    {
        List<Onderzoek> onderzoeken = _context.Onderzoeken.ToList<Onderzoek>();

        return Ok(onderzoeken);
    }

    [HttpPost("JoinOnderzoek")]
    public IActionResult GetJoinOnderzoek()
    {
        // Implementation goes here...

        return Ok();
    }
}