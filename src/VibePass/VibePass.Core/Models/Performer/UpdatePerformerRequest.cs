namespace VibePass.Core.Models.Performer;

public sealed record UpdatePerformerRequest(string Name, string LastName, string? About, DateTime? BirthDate);
