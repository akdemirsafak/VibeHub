namespace VibePass.Core.Models.Eventy;
public record UpdateEventyRequest(string Title, DateTime StartDate, DateTime EndDate, string Location, string? ImageUrl, string? Description);
