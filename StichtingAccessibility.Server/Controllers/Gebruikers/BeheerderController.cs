using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StichtingAccessibility.Server.Models;

namespace StichtingAccessibility.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BeheerderController : ControllerBase
{
    private readonly StichtingDbContext _context;

    public BeheerderController(StichtingDbContext context)
    {
        _context = context;
    }

    [HttpGet("Profiel")]
    public async Task<IActionResult> GetProfiel()
    {
        // Implementation goes here...

        return Ok();
    }

    [HttpPatch("Profiel")]
    public async Task<IActionResult> EditProfiel()
    {
        // Implementation goes here...

        return Ok();
    }
}