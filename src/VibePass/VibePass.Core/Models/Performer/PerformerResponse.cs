namespace VibePass.Core.Models.Performer;

public class PerformerResponse : BaseResponse
{
    private string Name { get; set; }
    private string LastName { get; set; }
    public string? About { get; set; }
    public DateTime? BirthDate { get; set; }
    public string FullName => $"{Name} {LastName}";
}
