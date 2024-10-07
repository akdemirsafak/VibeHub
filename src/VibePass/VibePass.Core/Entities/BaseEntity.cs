namespace VibePass.Core.Entities;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        Id= Guid.NewGuid().ToString();
    }
    public string Id { get; set; }
}
