namespace VibePod.Core.Models.Request;

public record UpdatePlanRequest(string Name, decimal Price, string? Description);