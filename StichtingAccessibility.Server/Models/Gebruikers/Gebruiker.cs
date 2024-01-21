using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace StichtingAccessibility.Server.Models;

public class Gebruiker : IdentityUser
{
    public DateTime DateOfBirth { get; set; }

    [NotMapped]
    public int Leeftijd 
    {
        get
        {
            var vandaag = DateTime.Today;
            var leeftijd = vandaag.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > vandaag.AddYears(-leeftijd)) leeftijd--;
            return leeftijd;
        }
    }

}