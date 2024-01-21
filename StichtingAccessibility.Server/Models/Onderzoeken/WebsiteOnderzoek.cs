namespace StichtingAccessibility.Server.Models;

public class WebsiteOnderzoek : Onderzoek
{
    public string Url { get; set; } = null!;

    public virtual Tracking? Tracking { get; set; }
}