public class getAllInviteDto
{
    public string Email { get; set; }
    public string Naam { get; set; }
    public Guid Indetifier { get; set; }
    public bool IsGebruikt { get; set; }
    public bool IsVerval { get; set; }
    public DateOnly VerloopDatum { get; set; }
    public DateOnly DatumGemaakt { get; set; }
    public string Uitgever { get; set; }
    public string Ontvanger { get; set; }
}