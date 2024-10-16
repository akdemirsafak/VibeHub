namespace VibePass.Core.Models.Performer;

public sealed record CreatePerformerRequest(string Name, string LastName, string? About, DateTime? BirthDate);
