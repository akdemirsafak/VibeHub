
using System.ComponentModel.DataAnnotations;

namespace VibePod.Core.Entities;

public class Vibe : BaseEntity, IAuditableEntity
{
    public Vibe()
    {
        //Playlists = new HashSet<Playlist>();
        Contents = new HashSet<Content>();
    }
    [Required, MinLength(3), MaxLength(32)]
    public string Name { get; set; }
    public string? ImageUrl { get; set; }
    //public virtual ICollection<Playlist> Playlists { get; set; }
    public virtual ICollection<Content> Contents { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
    public string? DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
}
