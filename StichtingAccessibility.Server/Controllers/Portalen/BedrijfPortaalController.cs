using Microsoft.AspNetCore.Mvc;

namespace StichtingAccessibility.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BedrijfPortaalController : ControllerBase
{
    [HttpGet("GetOnderzoeken")]
    public async Task<IActionResult> GetOnderzoeken()
    {
        // Implementation goes here...

        return Ok();
    }

    [HttpPost("CreateOnderzoek")]
    public async Task<IActionResult> CreateOnderzoek()
    {
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