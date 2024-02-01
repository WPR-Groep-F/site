using Microsoft.AspNetCore.Identity;
using StichtingAccessibility.Server.Models;

namespace StichtingAccessibility.Server.Data.Setup;

public class RoleSetup
{
    public static async Task InitializeAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var scopedServices = scope.ServiceProvider;

        var userManager = scopedServices.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = scopedServices.GetRequiredService<RoleManager<IdentityRole>>();

        List<string> rollen = new() { "Ervaringsdeskundig", "BedrijfMedewerker", "Beheerder" };

        await CreateRole(roleManager, rollen);
        await CreateUser(userManager, "Test", "Test123!", "Beheerder", "Beheerder");
        await CreateUser(userManager, "Rickevd", "Rickevd123!", "Ervaringsdeskundig", "Ervaringsdeskundig");
    }


    private static async Task CreateRole(RoleManager<IdentityRole> _roleManager, List<string> _role)
    {
        foreach (var role in _role)
            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));
            else
                Console.WriteLine("role already exists " + _role);
    }

    private static async Task DeleteUser(UserManager<IdentityUser> _userManager, string _userName)
    {
        var beheederuser = await _userManager.FindByNameAsync(_userName);

        if (beheederuser is not null)
        {
            var result = await _userManager.DeleteAsync(beheederuser);

            if (result.Succeeded)
                Console.WriteLine("succes");
            else
                Console.WriteLine("fail to delete" + _userName);
        }
    }

    private static async Task CreateUser(UserManager<IdentityUser> userManager, string userName, string password,
        string role, string userType)
    {
        if (userManager.FindByNameAsync(userName).Result is not null)
        {
            Console.WriteLine("user already exists " + userName);
            return;
        }

        IdentityUser user;
        switch (userType)
        {
            case "Beheerder":
                user = new Beheerder() { UserName = userName, Email = userName + "@example.com" };
                break;
            case "Ervaringsdeskundig":
                user = new Ervaringsdeskundig() { UserName = userName, Email = userName + "@example.com" };
                break;
            case "BedrijfsMedewerker":
                user = new BedrijfsMedewerker() { UserName = userName, Email = userName + "@example.com" };
                break;
            default:
                throw new ArgumentException("Invalid user type");
        }

        var result = await userManager.CreateAsync(user, password);

        if (result.Succeeded) await userManager.AddToRoleAsync(user, role);
    }
}