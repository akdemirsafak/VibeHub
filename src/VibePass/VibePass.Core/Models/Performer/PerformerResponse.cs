namespace VibePass.Core.Models.Performer;

public class PerformerResponse : BaseResponse
{
    public string FullName => $"{Name} {LastName}";
    public string? About { get; set; }
    public DateTime? BirthDate { get; set; }
    private string Name { get; set; }
    private string LastName { get; set; }
}
