using Microsoft.AspNetCore.Identity;

namespace VibePod.Core.Entities;

public class AppUser : IdentityUser, IAuditableEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public Plan Plan { get; set; }

    public DateTime CreatedAt { get ; set ; }
    public string CreatedBy { get ; set ; }
    public DateTime? UpdatedAt { get ; set ; }
    public string? UpdatedBy { get ; set ; }
    public bool IsDeleted { get ; set ; }
    public string? DeletedBy { get ; set ; }
    public DateTime? DeletedAt { get ; set ; }
}
