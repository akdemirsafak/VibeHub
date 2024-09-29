namespace VibePod.Core.Models.Request.Content;

public record UpdateContentRequest(string Name, 
    IList<string> SelectedCategories, 
    IList<string> SelectedMoods, 
    string? Lyrics, 
    string? Description);
