﻿namespace GameDevsConnect.Backend.Shared.Models;

public partial class ProjectModel
{
    public string Id { get; set; } = null!;

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? OwnerId { get; set; }

    public virtual UserModel? Owner { get; set; }

    public virtual ICollection<RequestModel> Requests { get; set; } = [];
}
