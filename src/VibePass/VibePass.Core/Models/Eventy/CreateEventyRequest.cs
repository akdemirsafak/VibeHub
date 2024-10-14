namespace VibePass.Core.Models.Eventy;

public record CreateEventyRequest(string Title, DateTime StartDate, DateTime EndDate, string Location, string? ImageUrl, string? Description);