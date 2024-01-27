using Microsoft.AspNetCore.Mvc.ModelBinding;

public class RegistreerIdentifierDto
{
    [BindRequired] public string Identifier { get; set; }
}