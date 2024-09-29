namespace VibePod.Core.Models.Request;

public record CreatePlanRequest(string Name, decimal Price, string? Description);