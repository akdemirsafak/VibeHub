using System.ComponentModel.DataAnnotations;

namespace VibePod.Core.Entities;

public class Content : BaseEntity, IAuditableEntity
{
    public Content()
    {
        Categories = new HashSet<Category>();
        Playlists = new HashSet<Playlist>();
    }
    [Required, MinLength(3), MaxLength(32)]
    public string Name { get; set; }
    [MaxLength(256)]
    public string? Description { get; set; }
    [MaxLength(256)]
    public string? Lyrics { get; set; }
    public string? ImageUrl { get; set; }
    public virtual ICollection<Category> Categories { get; set; }
    public virtual ICollection<Playlist> Playlists { get; set; }
    public virtual ICollection<Vibe> Vibes { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
    public string? DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
}
