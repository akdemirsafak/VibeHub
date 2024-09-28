namespace VibePod.Core.Models.Request;

public record CreatePlanRequest(string Name, string? Description, decimal Price);