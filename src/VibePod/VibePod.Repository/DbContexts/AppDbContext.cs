using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VibePod.Core.Entities;

namespace VibePod.Repository.DbContexts;

public sealed class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Plan> Plans { get; set; }
    public DbSet<Vibe> Vibes { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<Content> Contents { get; set; }
    public DbSet<Category> Categories { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<AppUser>(entity =>
        {
            entity.ToTable("Users");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        builder.Entity<AppRole>(entity =>
        {
            entity.ToTable("Roles");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });
        builder.Entity<Playlist>().Navigation(c => c.Contents).AutoInclude();
        builder.Entity<Content>().Navigation(x => x.Categories).AutoInclude();
        builder.Entity<Content>().Navigation(x => x.Vibes).AutoInclude();
    }
}