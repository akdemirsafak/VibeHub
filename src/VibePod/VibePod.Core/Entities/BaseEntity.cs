namespace VibePod.Core.Entities;

public abstract class BaseEntity
{
    public string Id { get; set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid().ToString();
    }
}
