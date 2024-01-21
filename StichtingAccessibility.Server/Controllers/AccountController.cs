using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StichtingAccessibility.Server.Models;
using StichtingAccessibility.Server.Models.DTOs.Ervaringsdeskundig;

namespace StichtingAccessibility.Server.Controllers;

public class GebruikerMetWachwoord : IdentityUser
{
    public string? Password { get; init; }
}

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost]
    [Route("registreer")]
    public async Task<ActionResult<IEnumerable<Customer>>> Registreer([FromBody] EVDRegistreerDto evdRegistreerDto)
    {
        var ervaringsdeskundig = new Ervaringsdeskundig
        {
            UserName = evdRegistreerDto.UserName,
            Email = evdRegistreerDto.Email
        };

        var resultaat = await _userManager.CreateAsync(ervaringsdeskundig, evdRegistreerDto.Password);
        if (!resultaat.Succeeded) return new BadRequestObjectResult(resultaat);

        await _userManager.AddToRoleAsync(ervaringsdeskundig, "Ervaringsdeskundig");
        return !resultaat.Succeeded ? new BadRequestObjectResult(resultaat) : StatusCode(201);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] GebruikerLogin gebruikerLogin)
    {
        var _user = await _userManager.FindByNameAsync(gebruikerLogin.UserName);
        if (_user == null) return NotFound("User name bestaat niet");

        if (!await _userManager.CheckPasswordAsync(_user, gebruikerLogin.Password))
            return Unauthorized("Wachtwoord is incorrect");

        var secret =
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    "awef98awef978haweof8g7aw789efhh789awef8h9awh89efh89awe98f89uawef9j8aw89hefawef"));
        var signingCredentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim> { new(ClaimTypes.Name, _user.UserName) };
        var roles = await _userManager.GetRolesAsync(_user);
        foreach (var role in roles)
            claims.Add(new Claim(ClaimTypes.Role, role));
        var tokenOptions = new JwtSecurityToken
        (
            "https://localhost:7047",
            "https://localhost:7047",
            claims,
            expires: DateTime.Now.AddMinutes(10),
            signingCredentials: signingCredentials
        );
        return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(tokenOptions) });
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok();
    }
}