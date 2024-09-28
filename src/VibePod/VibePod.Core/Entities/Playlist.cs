
using System.ComponentModel.DataAnnotations;

namespace VibePod.Core.Entities;

public class Playlist : BaseEntity, IAuditableEntity
{
    [Required, MinLength(3), MaxLength(32)]
    public string Name { get; set; }
    [MaxLength(256)]
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsPublic { get; set; }
    public bool IsFavorite { get; set; }

    public virtual ICollection<Content> Contents { get; set; }

    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
    public string? DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
}
