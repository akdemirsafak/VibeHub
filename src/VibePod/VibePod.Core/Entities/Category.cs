using System.ComponentModel.DataAnnotations;

namespace VibePod.Core.Entities;

public class Category : BaseEntity, IAuditableEntity
{
    [Required, MinLength(3), MaxLength(32)]
    public string Name { get; set; }
    public string? ImageUrl { get; set; }
    public virtual ICollection<Content> Contents { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
    public string? DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
}
