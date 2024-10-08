﻿namespace VibePod.Core.Entities;

public class Plan: BaseEntity, IAuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Duration { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public string? DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
}
