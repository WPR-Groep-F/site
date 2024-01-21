using Microsoft.AspNetCore.Mvc;

namespace StichtingAccessibility.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BeheerderPortaalController : ControllerBase
{
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
    public async Task<IActionResult> CreateBedrijf()
    {
        // Implementation goes here...

        return Ok();
    }
}