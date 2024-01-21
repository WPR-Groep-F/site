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

[Authorize(Roles = "BedrijfMedewerker")]
[Route("api/[controller]")]
[ApiController]
public class BedrijfsMedewerkerController : ControllerBase
{
    private readonly StichtingDbContext _context;
    private readonly SignInManager<IdentityUser> _signInManager;

    public BedrijfsMedewerkerController(StichtingDbContext context, SignInManager<IdentityUser> signInManager)
    {
        _context = context;
        _signInManager = signInManager;
    }

    [HttpGet("Profiel")]
    public async Task<IActionResult> GetProfiel()
    {
        return Ok();
    }

    [HttpPatch("Profiel")]
    public async Task<IActionResult> UpdateProfile()
    {
        return Ok();
    }
}