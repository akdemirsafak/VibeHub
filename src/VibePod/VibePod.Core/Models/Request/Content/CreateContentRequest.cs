using Microsoft.AspNetCore.Http;

namespace VibePod.Core.Models.Request.Content;

public record CreateContentRequest(
    string Name,
    //IFormFile ImageFile, 
    IList<string> SelectedCategories, 
    IList<string> SelectedMoods, 
    string? Lyrics, 
    string? Description);
